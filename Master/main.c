/*
 * Master.c
 *
 * Created: 25.05.2020 13:13:55
 * Author : Serhii-PC
 */ 


#define F_CPU 1843200UL

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include "Master.h"

int main(void)
{
	Setup();
	_delay_ms(500);
	sei();
	flag = 1;
	while (1)
	{
		if(rxOutPC != rxInPC)//if available
		{
			byteFromPC = readBufRXfromPC();
			if(flag == 1){
				setWriteModeRS485();//address
				UCSR1B |= (1 << TXB81);
				writeBufTXfromSlave(byteFromPC);
				flag = 2;
			}
			else if(flag == 2){//command
				flag = 0;
				command = byteFromPC;
				setWriteModeRS485();
				UCSR1B &= ~(1 << TXB81);//reset 8 bit
				writeBufTXfromSlave(byteFromPC);
				if(command == COMMAND_READ){
					flag = 1;
				}
			}
			else{//write
				if(command == COMMAND_WRITE)
				{
					setWriteModeRS485();
					UCSR1B &= ~(1 << TXB81);//reset 8 bit
					writeBufTXfromSlave(byteFromPC);
					++current_write_bytes;
					if(current_write_bytes == 1)
					{
						count_write_bytes = byteFromPC;
					}
					writeBufTXfromPC(current_write_bytes);
					if(current_write_bytes == count_write_bytes || current_write_bytes == MAX_COUNT_WRITE_BYTES)
					{
						flag = 1;
						current_write_bytes = 0;
					}
				}
				else{
					flag = 1;
					//print("reset");
				}
			}
		}
		if(rxOutSlave != rxInSlave)
		{
			writeBufTXfromPC(readBufRXfromSlave());
		}
	}
	return 0;
}