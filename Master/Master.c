/*
 * Master.c
 *
 * Created: 28.05.2020 17:08:38
 *  Author: Serhii-PC
 */ 
#include "Master.h"

volatile int8_t bufRXfromPC[BUF_SIZE_RX];
volatile int8_t bufTXfromPC[BUF_SIZE_TX];

volatile int8_t bufRXfromSlave[BUF_SIZE_RX];
volatile int8_t bufTXfromSlave[BUF_SIZE_RX];

volatile uint8_t rxInPC = 0, rxOutPC = 0, rxInSlave = 0, rxOutSlave = 0;
volatile uint8_t txInPC = 0, txOutPC = 0, txInSlave = 0, txOutSlave = 0;

uint8_t flag = 1;//0 - bit isAddress, 1 bit - isCommand
uint8_t byteFromPC = 0;
uint8_t byteFromSlave = 0;
uint8_t command = 0;
uint8_t count_write_bytes = 0;
uint8_t current_write_bytes = 0;

void Setup(void)
{
	//En_m
	DDRB |= (1 << EN_m);
	PORTB &= ~(1 << EN_m);
	//setup USART0 (master - PC) (RS-232)
	
	UCSR0A = 0;
	//interruption of receive, work receiver, transmitter:
	UCSR0B = (1 << RXCIE0)|(1 << UDRIE0)|(1 << RXEN0)|(1 << TXEN0);
	//8 bit, no parity, 1 stop bit:
	UCSR0C = (1 << UCSZ01)|(1 << UCSZ00);
	//speed : 9600 bps:
	UBRR0H = (uint8_t)(UBRR_CALC_RS_232 >> 8);
	UBRR0L = (uint8_t)(UBRR_CALC_RS_232);
	
	//setup USART1 (master - slave1, slave 2) (RS-485)
	
	UCSR1A = 0;
	//interruption of receive and transmit,UDRIE1, work receiver, transmitter:
	UCSR1B = (1 << RXCIE1)|(1 << TXCIE1)|(1 << UDRIE1)|(1 << RXEN1)|(1 << TXEN1)|(1 << UCSZ12);
	//9 bit, no parity, 1 stop bit:
	UCSR1C = (1 << UCSZ11)|(1 << UCSZ10);//(1 << UCSZ12);
	//speed : 19200 bps:
	UBRR1H = (uint8_t)(UBRR_CALC_RS_485 >> 8);
	UBRR1L = (uint8_t)(UBRR_CALC_RS_485);
}
/*************Master-PC*******************************/
//receiver from PC
ISR(USART0_RXC_vect)
{
	bufRXfromPC[rxInPC++] = UDR0;
	rxInPC &= BUF_MASK_RX;
	//added overflow check
}

////transmit from PC
ISR(USART0_UDRE_vect)
{
	UDR0 = bufTXfromPC[txOutPC++];
	txOutPC &= BUF_MASK_TX;
	if(txOutPC == txInPC)
	UCSR0B &= ~(1 << UDRIE0);
}
/*****************Master-Slaves**********************************/

//receiver from slaves
ISR(USART1_RXC_vect)
{
	bufRXfromSlave[rxInSlave++] = UDR1;
	rxInSlave &= BUF_MASK_RX;
}

ISR(USART1_TXC_vect)
{
	PORTB &= ~(1 << EN_m);
}

ISR(USART1_UDRE_vect)
{
	UDR1 = bufTXfromSlave[txOutSlave++];
	txOutSlave &= BUF_MASK_TX;
	if(txOutSlave == txInSlave)
	UCSR1B &= ~(1 << UDRIE1);
}

uint8_t readBufRXfromPC(void)
{
	uint8_t value = bufRXfromPC[rxOutPC++];
	rxOutPC &= BUF_MASK_RX;
	return value;
}

void writeBufTXfromPC(uint8_t value)
{
	bufTXfromPC[txInPC++] = value;
	txInPC &= BUF_MASK_TX;
	//added overflow check
	cli();
	UCSR0B |= (1 << UDRIE0);
	sei();
}

uint8_t readBufRXfromSlave(void)
{
	uint8_t value = bufRXfromSlave[rxOutSlave++];
	rxOutSlave &= BUF_MASK_RX;
	return value;
}

void writeBufTXfromSlave(uint8_t value)
{
	bufTXfromSlave[txInSlave++] = value;
	txInSlave &= BUF_MASK_TX;
	//added overflow check
	UCSR1B |= (1 << UDRIE1);
}

void setWriteModeRS485(void)
{
	PORTB |= (1 << EN_m);//enable transmit from slave mode
	_delay_ms(1);
}

void print(char *str)
{
	int i = 0;
	while(str[i] != '\0')
	{
		//_delay_ms(1);
		writeBufTXfromPC(str[i]);
		++i;
	}
}