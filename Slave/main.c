/*
 * Cource_work.c
 *
 * Created: 23.05.2020 19:16:36
 * Author : Serhii-PC
 */ 
//#define F_CPU 1843200UL
#define F_CPU 3686400UL
//#define F_CPU 6000000UL
#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdlib.h>

#define ADDRESS			    0x43
#define MOTOR_ADDRESS_A		0xC0
#define MOTOR_ADDRESS_B		0xC1
#define MODE_ADDRESS_1		0xE0
#define MODE_ADDRESS_2      0xE1  
#define MODE_ADDRESS_3      0xE2
#define POSITION_ADDRESS    0xE3//2 bytes
#define SPEED_ADDRESS       0xE4//1 byte
#define STOP_MOTOR_COMMAND  0xE5
#define START_MOTOR_COMMAND 0xE6
#define MAX_COUNT_BYTES 8
#define POSITION_X_CURSOR 4
#define SPEED_X_CURSOR 12
#define MODE_X_CURSOR 15
#define RADIX 10
#include "RS_485_slave.h"
#include "LCD_1602.h"
#include "Unipolar_step.h"

void Setup();
void parser();
void init_LCD();

uint8_t motor_commands = 0;
uint8_t write_command_address = 0;
uint8_t motor_number = 0;
uint8_t command = 0;
uint8_t count_write_bytes = 0;
uint8_t current_write_bytes = 0;
uint16_t input_position = 0;
uint8_t byteFromMaster = 0;
uint8_t y_cursor = 0;
uint8_t x_cursor = 0;
uint8_t bytes[MAX_COUNT_BYTES];
char number_buf[10];

int main(void)
{
	Setup();
	_delay_ms(600);
	sei();
	flag = 1;
	//LCD_WriteStr("Start client");
	
	
	init_LCD();
	motor_commands = 1;
	//mode_motorA = 2;
	while (1)
	{
		if(rxOut != rxIn)
		{
			byteFromMaster = readBufRX();
			if(flag == 1){
				if(byteFromMaster == ADDRESS){
					flag = (1 << 1);
					UCSRA &= ~(1 << MPCM);
				}
			}
			else if(flag == (1 << 1)){
				flag = 0;
				command = byteFromMaster;
				if(command == COMMAND_READ){
					flag = 1;
					//print_with_crc(string);
					LCD_WriteStr("Hello");
					
					UCSRA |= (1 << MPCM);
				}
			}
			else
			{
				if(command == COMMAND_WRITE)
				{
					 bytes[current_write_bytes++] = byteFromMaster;
					 if(current_write_bytes == 1)
						 count_write_bytes = byteFromMaster;
					 if(current_write_bytes == count_write_bytes || current_write_bytes == MAX_COUNT_BYTES)
					 {
						 flag = 1;
						 UCSRA |= (1 << MPCM);
						 if(calc_crc8_rohs(bytes, current_write_bytes - 1) == bytes[count_write_bytes - 1])
						 {
							parser(); 
						 }
						 count_write_bytes = current_write_bytes = 0;
						 motor_number = 0;
					 }	 	  
				}
				else{
					flag = 1;
					UCSRA |= (1 << MPCM);
				}
			}
		}	
	}
	return 0;
}

void parser()
{
	motor_commands = 1;
	uint8_t number_bytes = 0;
	for(uint8_t i = 0;i < current_write_bytes - 1;++i)
	{
		if(motor_commands == 1)
		{
			if(bytes[i] == MOTOR_ADDRESS_A){
				motor_number = 1;
				motor_commands = 2;
			}
			if(bytes[i] == MOTOR_ADDRESS_B){
				motor_number = 2;
				motor_commands = 2;
			}
		}
		else if(motor_commands == 2)
		{
			write_command_address = bytes[i];
			switch(write_command_address)
			{
				case STOP_MOTOR_COMMAND:
					if(motor_number == 1)
						motor_flag &= ~1;
					if(motor_number == 2)
						motor_flag &= ~(1 << 1);
					//motor_commands = 1;
					
					
					break;
				case START_MOTOR_COMMAND:
					if(motor_number == 1)
						motor_flag |= 1;
					if(motor_number == 2)
						motor_flag |= (1 << 1);
					break;
				case MODE_ADDRESS_1:
					if(motor_number == 1)
						mode_motorA = 0;
					if(motor_number == 2)
						mode_motorB = 0;
					LCD_GotoYX(motor_number, MODE_X_CURSOR);
					LCD_writeSymbol('1');
					break;
				case MODE_ADDRESS_2:
					if(motor_number == 1)
						mode_motorA = 1;
					if(motor_number == 2)
						mode_motorB = 1;
					LCD_GotoYX(motor_number, MODE_X_CURSOR);
					LCD_writeSymbol('2');
					break;
				case MODE_ADDRESS_3:
					if(motor_number == 1)
						mode_motorA = 2;
					if(motor_number == 2)
						mode_motorB = 2;	
					LCD_GotoYX(motor_number, MODE_X_CURSOR);
					LCD_writeSymbol('3');	
					break;
				default:
					motor_commands = 3;
			}
		}
		else if(motor_commands == 3)
		{
			if(write_command_address == POSITION_ADDRESS)
			{
				++number_bytes;
				if(number_bytes == 1)
				{
					input_position = bytes[i];
					input_position <<= 8;
				}
				if(number_bytes == 2)
				{
					input_position |= bytes[i];
					number_bytes = 0;
					if(motor_number == 1)
					{
						input_positionA = (int16_t)input_position;
						itoa(input_positionA, number_buf, RADIX);
					}
					if(motor_number == 2)
					{
						input_positionB = (int16_t)input_position;
						itoa(input_positionB, number_buf, RADIX);
					}
					LCD_GotoYX(motor_number, POSITION_X_CURSOR);
					LCD_clearRow(4);
					LCD_GotoYX(motor_number, POSITION_X_CURSOR);
					LCD_WriteStr(number_buf);
				}
			}
			else if(write_command_address == SPEED_ADDRESS)
			{
				if(motor_number == 1)
				{
					speed_prescalar_A = bytes[i];
					itoa(speed_prescalar_A, number_buf, RADIX);
				}
				if(motor_number == 2)
				{
					speed_prescalar_B = bytes[i];
					itoa(speed_prescalar_B, number_buf, RADIX);
				}
				LCD_GotoYX(motor_number, SPEED_X_CURSOR);
				LCD_WriteStr(number_buf);
			}
		}
	}
	return;	
}

void Setup()
{
	LCD_Setup();
	RS_485_Setup();
	Unipolar_Setup();
}

void init_LCD()
{
	LCD_GotoYX(1, 1);
	LCD_WriteStr("Ap:0   ,SP:1,M1");
	LCD_GotoYX(2, 1);
	LCD_WriteStr("Bp:0   ,SP:1,M1");
}