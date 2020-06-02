/*
 * added define ADDRESS
 * ATmega 32
 * RX - PD0
 * TX - PD1
 * En - PD2
 */ 

#ifndef RS_485_SLAVE_
#define RS_485_SLAVE_

//#define F_CPU 1843200UL
#define F_CPU 3686400UL
//#define F_CPU 6000000UL
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <avr/pgmspace.h>
#define BAUD_RS_485 9600
#define UBRR_CALC_RS_485 (F_CPU/(BAUD_RS_485*16L) - 1)
#define BUF_SIZE_RX 64
#define BUF_SIZE_TX 64
#define BUF_MASK_RX (BUF_SIZE_RX - 1)
#define BUF_MASK_TX (BUF_SIZE_TX - 1)
#define COMMAND_WRITE 0xA1
#define COMMAND_READ  0xB1
#define ENABLE PD2
#define SIZE_CRC_BLOCK 4
extern volatile int8_t bufRX[BUF_SIZE_RX];
extern volatile int8_t bufTX[BUF_SIZE_RX];
extern volatile uint8_t rxIn, rxOut, txIn, txOut;
extern volatile uint8_t flag;
extern const uint8_t CRC_8_ROHS_table[0x100] PROGMEM;
	
void RS_485_Setup();
ISR(USART_RXC_vect);
ISR(USART_UDRE_vect);
ISR(USART_TXC_vect);
uint8_t readBufRX(void);
void writeBufTX(uint8_t value);
void setWriteModeRS485(void);
void print_with_crc(const char *str);
uint8_t calc_crc8_rohs(uint8_t *block, uint8_t size);
void print(char *str);

#endif /* RS_485_SLAVE_ */