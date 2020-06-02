/*
 * LCD_1602.h
 *
 * Created: 01.03.2020
 *  Author: Serhii Senyk
 */ 

/*
	ATmega 32:
	data ports: PORTA (PA0 - PA7)
	command ports: PORTB (PB0 - PB3)
		RS - PB0
		RW - PB1
		E  - PB2

*/


#ifndef LCD_1602_H_
#define LCD_1602_H_


//#define F_CPU 1843200UL
#define F_CPU 3686400UL
//#define F_CPU 6000000UL
#include <avr/io.h>
#include <util/delay.h>
#include <avr/pgmspace.h>


#define RS 0
#define RW 1
#define E  2
#define DDR_DATA DDRA
#define PORT_DATA PORTA
#define PIN_DATA PINA

#define DDR_CONTROL DDRB
#define PORT_CONTROL PORTB
#define HIGH(port, pin) ((port) |= (1 << (pin)))
#define LOW(port, pin) ((port) &= ~(1 << (pin)))
#define DELAY_COM_US 0.10//0.20
#define DELAY 30//40

void LCD_Setup();
void LCD_PollBusyFlag();
void LCD_clear();
void LCD_WriteCommand(uint8_t command);
void LCD_writeSymbol(uint8_t symbol);
void LCD_GotoYX(uint8_t Y, uint8_t X);
void LCD_WriteStr(volatile char *str);
void LCD_WriteStrPROGMEM(volatile char *str);
void LCD_EnabledCursor();
void LCD_DisabledCursor();
void LCD_clearRow(uint8_t);


#endif /* LCD_1602_H_ */