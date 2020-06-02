/*
 * Unipolar_step.c
 *
 * Created: 25.05.2020 17:07:16
 *  Author: Serhii Senyk
 */ 

#include "Unipolar_step.h"

const uint8_t phases_step[3][8] = {{0b0001, 0b0010, 0b0100, 0b1000, 0b0001, 0b0010, 0b0100, 0b1000},//One phase
								 {0b0011, 0b0110, 0b1100, 0b1001, 0b0011, 0b0110, 0b1100, 0b1001},//Two phase
								 {0b0001, 0b0011, 0b0010, 0b0110, 0b0100, 0b1100, 0b1000, 0b1001}};//Half step
	
	
volatile int16_t current_positionA = 0;//first motor
volatile int16_t input_positionA = 0;
volatile int16_t current_positionB = 0;//second motor
volatile int16_t input_positionB = 0;

volatile uint8_t motor_flag = 0b11;//0bit - first motor, 1 bit - second motor, 
volatile int8_t i = 0;//first motor index
volatile int8_t k = 0;//second motor index
uint8_t mode_motorA = 0;
uint8_t mode_motorB = 0;
uint8_t speed_prescalar_A = 1;
uint8_t speed_prescalar_B = 1;
uint8_t currentA = 1;
uint8_t currentB = 1;

void Unipolar_Setup()
{
	DDR_MOTORS = 0xFF;
	PORT_MOTORS = 0;
	OCR0 = 0xFF;//for Proteus
	TCCR0 = (1 << WGM01) | (1 << CS02) | (1 << CS00); //CTC mode , clkI/O/1024(prescalar)
	TIMSK |= (1 << OCIE0);//interrupts
}

ISR(TIMER0_COMP_vect)
{
	  sei();
	  if(motor_flag&1)
	  {
		  if(currentA >= speed_prescalar_A)
		  {
			  if(input_positionA > current_positionA)
			  {
				  PORT_MOTORS &= ~0xF;
				  PORT_MOTORS |= phases_step[mode_motorA][i++];
				  i &= 0b111;
				  ++current_positionA;
			  }
			  else if(input_positionA < current_positionA)
			  {
				  PORT_MOTORS &= ~0xF;
				  PORT_MOTORS |= phases_step[mode_motorA][i--];
				  i &= 0b111;
				  --current_positionA;
			  }
			  currentA = 0;
		  }
		  ++currentA;
	  }
	  if((motor_flag >> 1)&1)
	  {
		  if(currentB >= speed_prescalar_B)
		  {
			  if(input_positionB > current_positionB)
			  {
				  PORT_MOTORS &= ~0xF0;
				  PORT_MOTORS |= (phases_step[mode_motorB][k++] << 4);
				  k &= 0b111;
				  ++current_positionB;
			  }
			  else if(input_positionB < current_positionB)
			  {
				  PORT_MOTORS &= ~0xF0;
				  PORT_MOTORS |= (phases_step[mode_motorB][k--] << 4);
				  k &= 0b111;
				  --current_positionB;
			  }
			  currentB = 0;
		  }
		  ++currentB;
	  } 
}