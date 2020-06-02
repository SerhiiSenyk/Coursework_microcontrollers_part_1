/*
 * Master.h
 *
 * Created: 28.05.2020 17:08:20
 *  Author: Serhii-PC
 */ 


#ifndef MASTER_H_
#define MASTER_H_

//#define F_CPU 1843200UL
#define F_CPU 3686400UL
//#define F_CPU 6000000UL
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>

#define BAUD_RS_485 9600
#define BAUD_RS_232 9600
#define UBRR_CALC_RS_485 (F_CPU/(BAUD_RS_485*16L) - 1)
#define UBRR_CALC_RS_232 (F_CPU/(BAUD_RS_232*16L) - 1)
#define BUF_SIZE_RX 64
#define BUF_SIZE_TX 64
#define BUF_MASK_RX (BUF_SIZE_RX - 1)
#define BUF_MASK_TX (BUF_SIZE_TX - 1)

#define COMMAND_WRITE 0xA1
#define COMMAND_READ  0xB1

#define EN_m PB1
#define MAX_COUNT_WRITE_BYTES 8

volatile int8_t bufRXfromPC[BUF_SIZE_RX];
volatile int8_t bufTXfromPC[BUF_SIZE_TX];

volatile int8_t bufRXfromSlave[BUF_SIZE_RX];
volatile int8_t bufTXfromSlave[BUF_SIZE_RX];

volatile uint8_t rxInPC, rxOutPC, rxInSlave, rxOutSlave;
volatile uint8_t txInPC, txOutPC, txInSlave, txOutSlave;

uint8_t byteFromPC, byteFromSlave, command;
uint8_t count_write_bytes, current_write_bytes ;

uint8_t flag;//0 - bit isAddress, 1 bit - isCommand

ISR(USART0_RXC_vect);
ISR(USART0_UDRE_vect);
ISR(USART1_RXC_vect);
ISR(USART1_TXC_vect);
ISR(USART1_UDRE_vect);


void Setup(void);
uint8_t readBufRXfromPC(void);
void writeBufTXfromPC(uint8_t value);
uint8_t readBufRXfromSlave(void);
void writeBufTXfromSlave(uint8_t value);
void setWriteModeRS485(void);
void print(char *str);



#endif /* MASTER_H_ */