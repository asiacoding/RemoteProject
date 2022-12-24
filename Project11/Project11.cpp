#include <string>
#include <stdio.h>
#include "stm32f1xx_hal.h"

void init()
{	
	
	__GPIOA_CLK_ENABLE();

	
	HAL_GPIO_WritePin(GPIOA, GPIO_PIN_1, GPIO_PIN_SET);
	

	
	GPIO_InitTypeDef initType = { 0 };

	initType.Pin = GPIO_PIN_1;
	initType.Mode =  GPIO_MODE_OUTPUT_PP;
	initType.Pull = GPIO_PULLUP;
	initType.Speed = GPIO_SPEED_FREQ_LOW;
	HAL_GPIO_Init(GPIOA, &initType);
}

int main()
{

	init();
	
	
	while (1)
	{
		HAL_GPIO_TogglePin(GPIOA, GPIO_PIN_1);
		HAL_Delay(1500);
	}
	

}