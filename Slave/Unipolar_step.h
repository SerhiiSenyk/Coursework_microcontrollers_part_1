/*
 * Unipolar_step.h
 *
 * Created: 25.05.2020
 *  Author: Serhii Senyk
 */ 

/*
 * 2 unipolar step motors
 * PORT C (0 - 3) - first motor
 * PORT C (4 - 7) - second motor
 *  
 */ 


#ifndef UNIPOLAR_STEP_H_
#define UNIPOLAR_STEP_H_
#include <avr/io.h>
#include <avr/interrupt.h>
#define DDR_MOTORS DDRC
#define PORT_MOTORS PORTC

volatile int16_t current_positionA, input_positionA, current_positionB, input_positionB;
uint8_t mode_motorA, mode_motorB, speed_prescalar_A, speed_prescalar_B;
volatile uint8_t motor_flag;

void Unipolar_Setup();
ISR(TIMER0_COMP_vect);



#endif /* UNIPOLAR_STEP_H_ */