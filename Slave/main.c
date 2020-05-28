/*
 * Cource_work.c
 *
 * Created: 23.05.2020 19:16:36
 * Author : Serhii-PC
 */ 
#define F_CPU 1843200UL
//#define F_CPU 4000000UL
#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdlib.h>

#define ADDRESS			    0x43
#define MOTOR_ADDRESS_A		0xC0
#define MOTOR_ADDRESS_B		0xC1
#define MODE_ADDRESS_1		0xE0//1 byte
#define MODE_ADDRESS_2       0xE1  
#define MODE_ADDRESS_3       0xE2
#define POSITION_ADDRESS    0xE3//2 bytes
#define SPEED_ADDRESS       0xE4//1byte
#define STOP_MOTOR_COMMAND  0xE5
#define START_MOTOR_COMMAND 0xE6
#define MAX_COUNT_BYTES 8


#include "RS_485_slave.h"
#include "LCD_1602.h"
#include "Unipolar_step.h"

void Setup();
void parser();
//0 bit - isAddress, 1 bit - isCommand, flag = 0 - isData

uint8_t motor_commands = 0;//0bit - motor, 1bit - position, 2bit - 
uint8_t address = 0;
uint8_t motor_number = 0;
uint8_t command = 0;
uint8_t count_write_bytes = 0;
uint8_t current_write_bytes = 0;
uint16_t input_position = 0;
uint8_t byteFromMaster = 0;
uint8_t bytes[MAX_COUNT_BYTES];

int main(void)
{
	Setup();
	_delay_ms(600);
	sei();
	flag = 1;
	LCD_WriteStr("Start client");
	motor_commands = 1;
	while (1)
	{
		if(rxOut != rxIn)
		{
			byteFromMaster = readBufRX();
			if(flag == 1){
				if(byteFromMaster == ADDRESS){
					flag = (1 << 1);
					UCSRA &= ~(1 << MPCM);
					LCD_clear();
					LCD_WriteStr("ADDRESS");
				}
			}
			else if(flag == (1 << 1)){
				flag = 0;
				command = byteFromMaster;
				LCD_clear();
				LCD_WriteStr("COMMAND_WRITE");
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
					 LCD_clear();
					 LCD_WriteStr("MOTOR_WRITE");
					 ++current_write_bytes;
					 if(current_write_bytes == 1)
					 {
						 count_write_bytes = byteFromMaster;
					 }
					 else{
						 bytes[current_write_bytes - 2] = byteFromMaster;
					 }
					 if(current_write_bytes == count_write_bytes || current_write_bytes == MAX_COUNT_BYTES)
					 {
						 LCD_clear();
						 LCD_WriteStr("END");
						 flag = 1;
						 UCSRA |= (1 << MPCM);
						 //if(calc_crc8_rohs(bytes, current_write_bytes - 2) == bytes[count_write_bytes - 2])
						 _delay_ms(1000);
						 if(bytes[current_write_bytes - 2] == 0xFF)
						 {
							LCD_clear();
							LCD_WriteStr("PARSER");
							_delay_ms(2000);
							parser(); 
						 }
						 count_write_bytes = current_write_bytes = 0;
						 motor_number = 0;
					 }	 	  
				}
				else{
					flag = 1;
					UCSRA |= (1 << MPCM);
					LCD_clear();
					LCD_WriteStr("RESET");
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
	for(uint8_t i = 0;i < current_write_bytes - 2;++i)
	{
		if(motor_commands == 1)
		{
			if(bytes[i] == MOTOR_ADDRESS_A){
				LCD_clear();
				LCD_WriteStr("MOTOR_ADDRESS_A");
				motor_number = 1;
				motor_commands = 2;
			}
			if(bytes[i] == MOTOR_ADDRESS_B){
				LCD_clear();
				LCD_WriteStr("MOTOR_ADDRESS_B");
				motor_number = 2;
				motor_commands = 2;
			}
		}
		else if(motor_commands == 2)
		{
			address = bytes[i];
			switch(address)
			{
				case STOP_MOTOR_COMMAND:
					if(motor_number == 1)
						motor_flag &= ~(1 << 1);
					if(motor_number == 2)
						motor_flag &= ~(1 << 2);
					motor_commands = 1;
					break;
				case START_MOTOR_COMMAND:
					if(motor_number == 1)
						motor_flag |= (1 << 1);
					if(motor_number == 2)
						motor_flag |= (1 << 2);
					motor_commands = 1;
					break;
				case MODE_ADDRESS_1:
					if(motor_number == 1)
						mode_motorA = 0;
					if(motor_number == 2)
						mode_motorB = 0;
					motor_commands = 1;
					break;
				case MODE_ADDRESS_2:
					if(motor_number == 1)
						mode_motorA = 1;
					if(motor_number == 2)
						mode_motorB = 1;
					motor_commands = 1;
					break;
				case MODE_ADDRESS_3:
					if(motor_number == 1)
						mode_motorA = 2;
					if(motor_number == 2)
						mode_motorB = 2;	
					motor_commands = 1;	
					break;
				default:
				LCD_clear();
				LCD_WriteStr("SET POSITION");
				motor_commands = 3;
			}
		}
		else if(motor_commands == 3)
		{
			if(address == POSITION_ADDRESS)
			{
				++number_bytes;
				if(number_bytes == 1)
				{
					input_position = bytes[i];
					input_position <<= 2;
				}
				if(number_bytes == 2)
				{
					input_position |= bytes[i];
					number_bytes = 0;
					if(motor_number == 1)
						input_positionA = (int16_t)input_position;
					if(motor_number == 2)
						input_positionB = (int16_t)input_position;
					LCD_clear();
					LCD_WriteStr("Input_position");
				}
			}
		}
		_delay_ms(2000);
	}
	return;	
}

void Setup()
{
	LCD_Setup();
	RS_485_Setup();
	Unipolar_Setup();
}