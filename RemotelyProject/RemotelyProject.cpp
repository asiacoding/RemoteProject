#include <string>
#include <stdio.h>
#include "stm32f1xx_hal.h"
//#include "IR.h"

//#define IR_Recive_Pin PB7


class BaseCodes {
public:

	void SetCode(std::string Code) {

		//RGB
		if (Code == "RGP1") {
			HAL_GPIO_TogglePin(GPIOA, GPIO_PIN_1);
		}
		if (Code == "RGP2") {
			HAL_GPIO_TogglePin(GPIOA, GPIO_PIN_2);
		}
		if (Code == "RGP3") 
		{
			HAL_GPIO_TogglePin(GPIOA, GPIO_PIN_3);
		}
		
		if (Code == "SendNum1")
		{
			
		}

		//Normal
		if (Code == "NormalLED1") {
			HAL_GPIO_TogglePin(GPIOC, GPIO_PIN_13);
		}
		if (Code == "NormalLED2") {
			HAL_GPIO_TogglePin(GPIOC, GPIO_PIN_14);
		}
		if (Code == "NormalLED3") {
			HAL_GPIO_TogglePin(GPIOC, GPIO_PIN_15);
		}

	}
};

class ConfigurationClass {
public:
	ConfigurationClass() {
		ConfingPins();
		
		
		__HAL_RCC_USART1_CLK_ENABLE(); //RCC->APB2ENR = (1 << 14); //Opne Prot Usart 1
	//10: Input with pull-up / pull-down
	//10: Output mode, max speed 2 MHz
		GPIOA->CRH = (0x0B << 4) | (4 << 8);
		USART1->BRR = 8000000 / 9600;
		USART1->CR1 = (1 << 2) | (1 << 3) | (1 << 13);
		SysTick->CTRL = (1 << 0) | (1 << 2);
		SysTick->LOAD = 8000 - 1;
		
		
		//	UART_InitTypeDef g = { 0 };
		//		HAL_UART_Init(&g);
			//	HAL_UART_Init(&g);
			
				//HAL_UART_Transmit()
			
			
			
			
			
			
			
			
			
			
				//	HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);
				//	USART1->BRR = 8000000 / 9600;
	}
	void ConfingPins() {
		//Base Class Stm32F103 in Stm32clbeIDE
		//GPIO_InitTypeDef GPIO_InitStruct = { 0 };

		__HAL_RCC_GPIOA_CLK_ENABLE();
		__HAL_RCC_GPIOB_CLK_ENABLE();
		__HAL_RCC_GPIOC_CLK_ENABLE();

		__HAL_RCC_USART1_CLK_ENABLE(); //RCC->APB2ENR = (1 << 14); //Opne Prot Usart 1

		HAL_GPIO_WritePin(GPIOA, GPIO_PIN_1, GPIO_PIN_RESET);
		HAL_GPIO_WritePin(GPIOA, GPIO_PIN_2, GPIO_PIN_RESET);
		HAL_GPIO_WritePin(GPIOA, GPIO_PIN_3, GPIO_PIN_RESET);

		HAL_GPIO_WritePin(GPIOC, GPIO_PIN_13, GPIO_PIN_RESET);
		HAL_GPIO_WritePin(GPIOC, GPIO_PIN_14, GPIO_PIN_RESET);
		HAL_GPIO_WritePin(GPIOC, GPIO_PIN_15, GPIO_PIN_RESET);

		GPIO_InitTypeDef GPIO_InitStruct = { 0 };
		
		GPIO_Init_Pin(GPIOA, GPIO_InitStruct, GPIO_PIN_1 | GPIO_PIN_2 | GPIO_PIN_3 | GPIO_PIN_9, GPIO_MODE_OUTPUT_PP, GPIO_PULLUP, GPIO_SPEED_FREQ_LOW);
		GPIO_Init_Pin(GPIOA, GPIO_InitStruct, GPIO_PIN_10, GPIO_MODE_INPUT, GPIO_PULLUP, GPIO_SPEED_FREQ_LOW);
		GPIO_Init_Pin(GPIOC, GPIO_InitStruct, GPIO_PIN_13 | GPIO_PIN_14 | GPIO_PIN_15, GPIO_MODE_OUTPUT_PP, GPIO_PULLUP, GPIO_SPEED_FREQ_LOW);
	}
	
	void GPIO_Init_Pin(GPIO_TypeDef* Port, GPIO_InitTypeDef GPIO_InitStruct, uint32_t Pins, uint32_t GPIO_MODE_xx, uint32_t GPIO_pull_type, uint32_t GPIO_SPEED_xxx) // GPIO_MODE_
	{
	
		GPIO_InitStruct.Pin = Pins;//GPIO_PIN_13 | GPIO_PIN_14 | GPIO_PIN_15;
		GPIO_InitStruct.Mode = GPIO_MODE_xx;
		GPIO_InitStruct.Pull = GPIO_pull_type;
		GPIO_InitStruct.Speed = GPIO_SPEED_xxx;
		HAL_GPIO_Init(Port, &GPIO_InitStruct);
	}
	
	void Write(std::string SendMsg) {
		int X = 0;
		int Max = SendMsg.length();
		for (; X < Max;) {

			USART1->DR = (SendMsg[X]);
			// Wait for TC to SET.. This indicates that the data has been transmitted
			while (!(USART1->SR & USART_SR_TXE_Msk)) ;
			X += 1;
		}
	}

	unsigned char Read() {
		while (!(USART1->SR & (1 << 5))) ;
		return USART1->DR & 0x00FF;
	}
	

};


int main(void) { 
	ConfigurationClass obj1;
	BaseCodes obj2;
	std::string Code = "";
	while (1) {
		unsigned char GetFromUart = obj1.Read();
		//obj1.Write("Wlecome Ahmed;");
		if (GetFromUart != ';') {
			Code += GetFromUart;
		}
		else 
		{
			if (Code == "GetTheWeather") 
			{
				obj1.Write("Nice To Jobs");
			}
			else 
			{
				obj2.SetCode(Code);
			}
			Code = "";
		}
	}
	
	return 0;
}






