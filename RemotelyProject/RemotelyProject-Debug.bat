@echo off
REM Run this file to build the project outside of the IDE.
REM WARNING: if using a different machine, copy the .rsp files together with this script.
echo RemotelyProject.cpp
"D:\Programs\stm32 Package\bin\arm-none-eabi-g++.exe" @"VisualGDB/Debug/RemotelyProject.gcc.rsp" || exit 1
echo startup_stm32f103xb.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/StartupFiles/startup_stm32f103xb.gcc.rsp" || exit 1
echo system_stm32f1xx.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/CMSIS_HAL/Device/ST/STM32F1xx/Source/Templates/system_stm32f1xx.gcc.rsp" || exit 1
echo stm32f1xx_hal.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal.gcc.rsp" || exit 1
echo stm32f1xx_hal_adc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_adc.gcc.rsp" || exit 1
echo stm32f1xx_hal_adc_ex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_adc_ex.gcc.rsp" || exit 1
echo stm32f1xx_hal_can.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_can.gcc.rsp" || exit 1
echo stm32f1xx_hal_cec.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_cec.gcc.rsp" || exit 1
echo stm32f1xx_hal_cortex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_cortex.gcc.rsp" || exit 1
echo stm32f1xx_hal_crc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_crc.gcc.rsp" || exit 1
echo stm32f1xx_hal_dac.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_dac.gcc.rsp" || exit 1
echo stm32f1xx_hal_dac_ex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_dac_ex.gcc.rsp" || exit 1
echo stm32f1xx_hal_dma.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_dma.gcc.rsp" || exit 1
echo stm32f1xx_hal_eth.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_eth.gcc.rsp" || exit 1
echo stm32f1xx_hal_exti.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_exti.gcc.rsp" || exit 1
echo stm32f1xx_hal_flash.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_flash.gcc.rsp" || exit 1
echo stm32f1xx_hal_flash_ex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_flash_ex.gcc.rsp" || exit 1
echo stm32f1xx_hal_gpio.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_gpio.gcc.rsp" || exit 1
echo stm32f1xx_hal_gpio_ex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_gpio_ex.gcc.rsp" || exit 1
echo stm32f1xx_hal_hcd.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_hcd.gcc.rsp" || exit 1
echo stm32f1xx_hal_i2c.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_i2c.gcc.rsp" || exit 1
echo stm32f1xx_hal_i2s.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_i2s.gcc.rsp" || exit 1
echo stm32f1xx_hal_irda.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_irda.gcc.rsp" || exit 1
echo stm32f1xx_hal_iwdg.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_iwdg.gcc.rsp" || exit 1
echo stm32f1xx_hal_mmc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_mmc.gcc.rsp" || exit 1
echo stm32f1xx_hal_nand.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_nand.gcc.rsp" || exit 1
echo stm32f1xx_hal_nor.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_nor.gcc.rsp" || exit 1
echo stm32f1xx_hal_pccard.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_pccard.gcc.rsp" || exit 1
echo stm32f1xx_hal_pcd.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_pcd.gcc.rsp" || exit 1
echo stm32f1xx_hal_pcd_ex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_pcd_ex.gcc.rsp" || exit 1
echo stm32f1xx_hal_pwr.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_pwr.gcc.rsp" || exit 1
echo stm32f1xx_hal_rcc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_rcc.gcc.rsp" || exit 1
echo stm32f1xx_hal_rcc_ex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_rcc_ex.gcc.rsp" || exit 1
echo stm32f1xx_hal_rtc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_rtc.gcc.rsp" || exit 1
echo stm32f1xx_hal_rtc_ex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_rtc_ex.gcc.rsp" || exit 1
echo stm32f1xx_hal_sd.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_sd.gcc.rsp" || exit 1
echo stm32f1xx_hal_smartcard.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_smartcard.gcc.rsp" || exit 1
echo stm32f1xx_hal_spi.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_spi.gcc.rsp" || exit 1
echo stm32f1xx_hal_sram.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_sram.gcc.rsp" || exit 1
echo stm32f1xx_hal_tim.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_tim.gcc.rsp" || exit 1
echo stm32f1xx_hal_tim_ex.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_tim_ex.gcc.rsp" || exit 1
echo stm32f1xx_hal_uart.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_uart.gcc.rsp" || exit 1
echo stm32f1xx_hal_usart.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_usart.gcc.rsp" || exit 1
echo stm32f1xx_hal_wwdg.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_hal_wwdg.gcc.rsp" || exit 1
echo stm32f1xx_ll_usb.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_usb.gcc.rsp" || exit 1
echo stm32f1xx_ll_adc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_adc.gcc.rsp" || exit 1
echo stm32f1xx_ll_crc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_crc.gcc.rsp" || exit 1
echo stm32f1xx_ll_dac.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_dac.gcc.rsp" || exit 1
echo stm32f1xx_ll_dma.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_dma.gcc.rsp" || exit 1
echo stm32f1xx_ll_exti.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_exti.gcc.rsp" || exit 1
echo stm32f1xx_ll_fsmc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_fsmc.gcc.rsp" || exit 1
echo stm32f1xx_ll_gpio.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_gpio.gcc.rsp" || exit 1
echo stm32f1xx_ll_i2c.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_i2c.gcc.rsp" || exit 1
echo stm32f1xx_ll_pwr.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_pwr.gcc.rsp" || exit 1
echo stm32f1xx_ll_rcc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_rcc.gcc.rsp" || exit 1
echo stm32f1xx_ll_rtc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_rtc.gcc.rsp" || exit 1
echo stm32f1xx_ll_sdmmc.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_sdmmc.gcc.rsp" || exit 1
echo stm32f1xx_ll_spi.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_spi.gcc.rsp" || exit 1
echo stm32f1xx_ll_tim.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_tim.gcc.rsp" || exit 1
echo stm32f1xx_ll_usart.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_usart.gcc.rsp" || exit 1
echo stm32f1xx_ll_utils.c
"D:\Programs\stm32 Package\bin\arm-none-eabi-gcc.exe" @"VisualGDB/Debug/__BSP_ROOT__/STM32F1xxxx/STM32F1xx_HAL_Driver/Src/stm32f1xx_ll_utils.gcc.rsp" || exit 1
echo Linking ../VisualGDB/Debug/RemotelyProject...
"D:\Programs\stm32 Package\bin\arm-none-eabi-g++.exe" @../VisualGDB/Debug/RemotelyProject.link.rsp || exit 1
"D:\Programs\stm32 Package\bin\arm-none-eabi-objcopy.exe" @../VisualGDB/Debug/RemotelyProject.mkbin.rsp || exit 1
