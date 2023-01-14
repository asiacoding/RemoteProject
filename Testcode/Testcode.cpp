#include <stdio.h>
#include <iostream>

void SendSegnle() {
	char Mystr[36] = "";
	int SendingValue = 16738455;

	sprintf(Mystr, "%x", SendingValue);

	for (int x = 0; x > x + 1; x++)
	{

		if (Mystr[x] == '1') {
		//	HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_SET);
		}
		else {
	//		HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_RESET);
		};
	}
//	HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_RESET);
}


int main()
{
	SendSegnle();
}

