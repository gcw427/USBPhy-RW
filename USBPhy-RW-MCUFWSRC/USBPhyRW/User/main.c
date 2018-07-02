/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "usart.h"
#include "usb_lib.h"
#include "hw_config.h"
#include "usbio.h"

extern uint8_t USB_Received_Flag;
#define FWVer v018
//define pins
#define HIGH		1
#define LOW			0
#define SMI_MDC 	GPIO_Pin_0	//PB
#define SMI_MDIO 	GPIO_Pin_1	//PB
#define SMI_MDIO_HIGH GPIO_SetBits(GPIOB,GPIO_Pin_1)
#define SMI_MDIO_LOW GPIO_ResetBits(GPIOB,GPIO_Pin_1)
#define PHYHWRSTE 0
#define PHYHWRSTD 1

/**
  * @brief  串口打印输出
  * @param  None
  * @retval None
  */
	void USB_Cable_Config2 (FunctionalState NewState)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOE, ENABLE);

  /* PE3 输出 0 时 D+ 接上拉电阻工作于全速模式 */ 
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_3;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_OD;	   /* 开漏输出 */
  GPIO_Init(GPIOE, &GPIO_InitStructure);
	
	 
  if (NewState != DISABLE)
  {
    GPIO_ResetBits(GPIOE, GPIO_Pin_3);		             /* USB全速模式 */
  }
  else
  {
    GPIO_SetBits(GPIOE, GPIO_Pin_3);			             /* 普通模式 */
  }
}
//FOR SMI DRIVER BY DANZA
void Delayms(uint32_t delayms)
{
	uint32_t i;
	while(delayms--)
	{
		i=12000;
		while(i--);
	}
}

void dataLED_CONFIG()
{
	GPIO_InitTypeDef DataLED;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC,ENABLE);
	DataLED.GPIO_Pin= GPIO_Pin_13;
	DataLED.GPIO_Speed = GPIO_Speed_2MHz;
	DataLED.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_Init(GPIOC,&DataLED);
	GPIO_ResetBits(GPIOC,GPIO_Pin_13);
	Delayms(1000);
	GPIO_SetBits(GPIOC,GPIO_Pin_13);
}

void BlinkDataLed(void)
{
		GPIO_ResetBits(GPIOC,GPIO_Pin_13);
		Delayms(200);
		GPIO_SetBits(GPIOC,GPIO_Pin_13);
}
//*****************************************SMI MDC/MDIO BEGIN************************//
//CLK PP OUT ENABLE pb-0
void smiMDC_CONFIG()
{
		GPIO_InitTypeDef SMI_CLK;
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB,ENABLE);
		SMI_CLK.GPIO_Pin = GPIO_Pin_0;
		SMI_CLK.GPIO_Mode = GPIO_Mode_Out_PP;
		SMI_CLK.GPIO_Speed = GPIO_Speed_2MHz;
		GPIO_Init(GPIOB,&SMI_CLK);
		//default set mdc low
		GPIO_ResetBits(GPIOB,GPIO_Pin_0);
}
//MDIO pb-1;
void smiMDIO_CONFIG(IOMODE IO)
{
		GPIO_InitTypeDef SMIMDIO;
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB,ENABLE);
		SMIMDIO.GPIO_Pin = GPIO_Pin_1;
		if(IO == OUTPUT)
		{
				SMIMDIO.GPIO_Mode = GPIO_Mode_Out_PP;
		}
		else 
				SMIMDIO.GPIO_Mode = GPIO_Mode_IPU;
		
		SMIMDIO.GPIO_Speed = GPIO_Speed_2MHz;
		GPIO_Init(GPIOB,&SMIMDIO);
}

//SMI INIT
void smiInit(void)
{
	smiMDC_CONFIG();
	smiMDIO_CONFIG(OUTPUT);
	//debug for some issue by danza
	SMI_MDIO_HIGH;
}

//MDC act as CLK. 45KHz
void pulseMdc(void)
{
	uint32_t i=0;
	GPIO_ResetBits(GPIOB,GPIO_Pin_0);
	//GPIO_SetBits(GPIOB,GPIO_Pin_0);
	//45kHz
	for(i=0;i<50;i++)
	{
		__ASM("NOP");
	}
	GPIO_SetBits(GPIOB,GPIO_Pin_0);
	//GPIO_ResetBits(GPIOB,GPIO_Pin_0);
	for(i=0;i<50;i++)
	{
		__ASM("NOP");
	}
	GPIO_SetBits(GPIOB,GPIO_Pin_0);
}


void delay_us(uint32_t time)
{
	uint32_t i=8*time;
	while(i--);
}

void delay_usx(uint32_t time)
{
	uint32_t i=1*time;
	while(i--);
}
void pulseMdc8226(void)
{
	//uint32_t i=0;
	GPIO_ResetBits(GPIOB,GPIO_Pin_0);
	//GPIO_SetBits(GPIOB,GPIO_Pin_0);
	/*for(i=0;i<5;i++)
	{
		__ASM("NOP");
	}*/
	delay_us(1);
	GPIO_SetBits(GPIOB,GPIO_Pin_0);
	//GPIO_ResetBits(GPIOB,GPIO_Pin_0);
	/*for(i=0;i<1;i++)
	{
		__ASM("NOP");
	}*/
	delay_usx(1);
	//GPIO_SetBits(GPIOB,GPIO_Pin_0);
}

//SMIWRITE
//PHYADDR
//REGADDR
//REGVALUE
void smiWrite(uint8_t phy, uint8_t reg, uint16_t dat)
{
	uint8_t byte;
  uint16_t word;
	smiMDIO_CONFIG(OUTPUT);
	SMI_MDIO_HIGH;
	for (byte = 0; byte < 32; byte++)
		pulseMdc();
	//start code 01
	SMI_MDIO_LOW;
	pulseMdc();
	SMI_MDIO_HIGH;
	pulseMdc();
	//write code  01
	SMI_MDIO_LOW;
	pulseMdc();
	SMI_MDIO_HIGH;
	pulseMdc();
	//phy addr
	for (byte=0x10; byte!=0; byte=byte>>1)
	{
		if (byte & phy)
			SMI_MDIO_HIGH;
		else
			SMI_MDIO_LOW;
		pulseMdc();
	}
	//reg addr
	 for (byte=0x10; byte!=0; byte=byte>>1)
	{
		 if (byte & reg)
			 SMI_MDIO_HIGH;
		 else
			 SMI_MDIO_LOW;
		 pulseMdc();
	}
	//turn around -TA
	 SMI_MDIO_HIGH;
	 pulseMdc();
	 SMI_MDIO_LOW;
	 pulseMdc();
	//data 
	for(word=0x8000; word!=0; word=word>>1)
	{
		if (word & dat)
			SMI_MDIO_HIGH;
		else
			SMI_MDIO_LOW;
		pulseMdc();
	}
	pulseMdc();
	//多加7个clk周期 WA for RTL8211E
	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();
	Delayms(1);
}

void smiWriteAddr_8226(uint8_t prtad, uint8_t devad, uint16_t address)
{
	uint8_t byte;
  uint16_t word;
	smiMDIO_CONFIG(OUTPUT);
	SMI_MDIO_HIGH;
	for (byte = 0; byte < 32; byte++)
		pulseMdc8226();
	//start code 00
	SMI_MDIO_LOW;
	pulseMdc8226();
	SMI_MDIO_LOW; 
	pulseMdc8226();
	//Address code  00
	SMI_MDIO_LOW;
	pulseMdc8226();
	SMI_MDIO_LOW;
	pulseMdc8226();
	//phy addr
	for (byte=0x10; byte!=0; byte=byte>>1)
	{
		if (byte & prtad)
			SMI_MDIO_HIGH;
		else
			SMI_MDIO_LOW;
		pulseMdc8226();
	}
	//reg addr
	 for (byte=0x10; byte!=0; byte=byte>>1)
	{
		 if (byte & devad)
			 SMI_MDIO_HIGH;
		 else
			 SMI_MDIO_LOW;
		 pulseMdc8226();
	}
	//turn around -TA 1->0
	 SMI_MDIO_HIGH;
	 pulseMdc8226();
	 SMI_MDIO_LOW;
	 pulseMdc8226();
	//data 
	for(word=0x8000; word!=0; word=word>>1)
	{
		if (word & address)
			SMI_MDIO_HIGH;
		else
			SMI_MDIO_LOW;
		pulseMdc8226();
	}
	pulseMdc8226();
	//多加7个clk周期 WA for RTL8211E
/*	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();*/
	//Delayms(1);
}

void smiWriteReg_8226(uint8_t prtad, uint8_t devad, uint16_t regdata)
{
	uint8_t byte;
  uint16_t word;
	smiMDIO_CONFIG(OUTPUT);
	SMI_MDIO_HIGH;
	for (byte = 0; byte < 32; byte++)
		pulseMdc8226();
	//start code 00
	SMI_MDIO_LOW;
	pulseMdc8226();
	SMI_MDIO_LOW; 
	pulseMdc8226();
	//Address code  01
	SMI_MDIO_LOW;
	pulseMdc8226();
	SMI_MDIO_HIGH;
	pulseMdc8226();
	//phy addr
	for (byte=0x10; byte!=0; byte=byte>>1)
	{
		if (byte & prtad)
			SMI_MDIO_HIGH;
		else
			SMI_MDIO_LOW;
		pulseMdc8226();
	}
	//reg addr
	 for (byte=0x10; byte!=0; byte=byte>>1)
	{
		 if (byte & devad)
			 SMI_MDIO_HIGH;
		 else
			 SMI_MDIO_LOW;
		 pulseMdc8226();
	}
	//turn around -TA 1->0
	 SMI_MDIO_HIGH;
	 pulseMdc8226();
	 SMI_MDIO_LOW;
	 pulseMdc8226();
	//data 
	for(word=0x8000; word!=0; word=word>>1)
	{
		if (word & regdata)
			SMI_MDIO_HIGH;
		else
			SMI_MDIO_LOW;
		pulseMdc8226();
	}
	pulseMdc8226();
	//多加7个clk周期 WA for RTL8211E
/*	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();
	pulseMdc();*/
	//Delayms(1);
}

void smiReadReg_8226(uint8_t prtad, uint8_t devad, uint16_t *regdat)
{
	  uint8_t byte;
    uint16_t word;
		/* SMI_MDIO pin is output */
		smiMDIO_CONFIG(OUTPUT);
		SMI_MDIO_HIGH;
		for (byte = 0; byte < 32; byte++)
					pulseMdc8226();
		//start code 00
		SMI_MDIO_LOW;
		pulseMdc8226();
		SMI_MDIO_LOW;
		pulseMdc8226();
		//read code 11
		SMI_MDIO_HIGH;
		pulseMdc8226();
		SMI_MDIO_HIGH;
		pulseMdc8226();
		//phy addr
		for (byte=0x10; byte!=0;)
		{
				if (byte & prtad)
					SMI_MDIO_HIGH;
				else
					SMI_MDIO_LOW;
				pulseMdc8226();
				byte=byte>>1;	
		}
		//reg addr
		 for (byte=0x10; byte!=0;)
		{
				if (byte & devad)
					SMI_MDIO_HIGH;
				else
					SMI_MDIO_LOW;
				pulseMdc8226();
        byte=byte>>1;
		}
		//TA
		smiMDIO_CONFIG(INPUT);
		pulseMdc8226();
    pulseMdc8226();
		*regdat = 0;
		for(word=0x8000; word!=0;)
		{
				if(GPIO_ReadInputDataBit(GPIOB,GPIO_Pin_1) == Bit_SET)
						*regdat |= word;
				pulseMdc8226();
				word=word>>1;
		}
/*		pulseMdc();
		pulseMdc();
		pulseMdc();
		pulseMdc();
		pulseMdc();
		pulseMdc();*/
}

//write 1
void smiSetBit_8226(uint8_t prtad, uint8_t devad, uint16_t address,uint8_t bit)
{
	uint16_t rxdata;
	smiWriteAddr_8226(prtad,devad,address);
	smiReadReg_8226(prtad,devad,&rxdata); 
	Delayms(1);
	smiWriteAddr_8226(prtad,devad,address);
	smiWriteReg_8226(prtad,devad,(rxdata | (1<<bit)));
}

//write 0
void smiResetBit_8226(uint8_t prtad, uint8_t devad, uint16_t address,uint8_t bit)
{
	uint16_t rydata;
	smiWriteAddr_8226(prtad,devad,address);
	smiReadReg_8226(prtad,devad,&rydata); 
	Delayms(1);
	smiWriteAddr_8226(prtad,devad,address);
	smiWriteReg_8226(prtad,devad,(rydata & (~(1<<bit))));
}
//SMIREAD
//PHYADDR
//REGADDR
//Data store pointer
void smiRead(uint8_t phy, uint8_t reg, uint16_t *dat)
{
	  uint8_t byte;
    uint16_t word;
		/* SMI_MDIO pin is output */
		smiMDIO_CONFIG(OUTPUT);
		SMI_MDIO_HIGH;
		for (byte = 0; byte < 32; byte++)
					pulseMdc();
		//start code 01
		SMI_MDIO_LOW;
		pulseMdc();
		SMI_MDIO_HIGH;
		pulseMdc();
		//read code 10
		SMI_MDIO_HIGH;
		pulseMdc();
		SMI_MDIO_LOW;
		pulseMdc();
		//phy addr
		for (byte=0x10; byte!=0;)
		{
				if (byte & phy)
					SMI_MDIO_HIGH;
				else
					SMI_MDIO_LOW;
				pulseMdc();
				byte=byte>>1;	
		}
		//reg addr
		 for (byte=0x10; byte!=0;)
		{
				if (byte & reg)
					SMI_MDIO_HIGH;
				else
					SMI_MDIO_LOW;
				pulseMdc();
        byte=byte>>1;
		}
		//TA
		smiMDIO_CONFIG(INPUT);
		pulseMdc();
    pulseMdc();
		*dat = 0;
		for(word=0x8000; word!=0;)
		{
				if(GPIO_ReadInputDataBit(GPIOB,GPIO_Pin_1) == Bit_SET)
						*dat |= word;
				pulseMdc();
				word=word>>1;
		}
		pulseMdc();
		pulseMdc();
		pulseMdc();
		pulseMdc();
		pulseMdc();
		pulseMdc();
		pulseMdc();
}
int rtk_reg_set(uint16_t phyad,uint16_t regad,uint16_t npage,uint16_t value)
{
	//switch page;
	smiWrite(0,31,npage);
	smiWrite(0,regad,value);
	return 0;
}

int rtk_reg_get(uint16_t phyad, uint16_t regad, uint16_t npage, uint16_t *pvalue)
{
		return 0;
}
//**************************************SMI MDC/MDIO END*****************************//
//*****************************************PHY RESET*********************************//
//PA1 for PHY HWRST
void phyRST_CONFIG()
{
	GPIO_InitTypeDef PHYRST;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA,ENABLE);
	PHYRST.GPIO_Pin = GPIO_Pin_1;
	PHYRST.GPIO_Mode = GPIO_Mode_Out_PP;
	PHYRST.GPIO_Speed = GPIO_Speed_2MHz;
	GPIO_Init(GPIOA,&PHYRST);
	GPIO_SetBits(GPIOA,GPIO_Pin_1);
}
void phyHwRST()
{
					GPIO_ResetBits(GPIOA,GPIO_Pin_1);
					Delayms(15);
					GPIO_SetBits(GPIOA,GPIO_Pin_1);
}

void phySwRST()
{
	uint16_t rdata;
	smiWrite(0x00,31,0x0000);
	smiRead(0x00,0x00,&rdata);
	smiWrite(0x00,0x00,(rdata | 0x8000));
}


//******************************************IOL TEST Begin*************************//
//chip type:
//01 -> 8211F
//02 -> 8211E(-VB)
//03 -> 8211DS
//04 -> 8201F-VA(8201FN-VA/8201FL-VA)
//05 -> 8201FR
//06 -> 8201F-VB(8201FN-VB/8201FL-VB/8201FR-VB)
//07 -> 8201FNI-VC
//08 -> 8201F-VD(8201FR-VD)
//09 -> 8201E
//0a -> 8211D
int iolGiga_TestMode1_En(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01:	smiWrite(0,31,0x0000);smiWrite(0,9,0x2000);break;
		case 0x02:  smiWrite(0,31,0x0005);smiWrite(0,5,0x8b86);smiWrite(0,6,0xe200);smiWrite(0,31,0x0007);smiWrite(0,30,0x0020);smiWrite(0,21,0x0108);smiWrite(0,31,0x0000); //initial setting
								smiWrite(0,31,0);smiWrite(0,9,0x2000);break;
		case 0x03: 	smiWrite(0,31,0x0002);smiWrite(0,2,0xc22b);smiWrite(0,31,0x0000);smiWrite(0,9,0x2000);break;
		case 0x0a:	smiWrite(0,31,0x0002);smiWrite(0,2,0xc22b);smiWrite(0,31,0x0000);smiWrite(0,9,0x2000);break;
	}
	return 0;
}
int iolGiga_TestMode1_Dis(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);break;
		case 0x02: 	smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);
								smiWrite(0,31,0x0005);smiWrite(0,5,0x8b86);smiWrite(0,6,0xe201);smiWrite(0,31,0x0007);smiWrite(0,30,0020);smiWrite(0,21,0x1108);smiWrite(0,31,0x0000);break;
		case 0x03: 	smiWrite(0,31,0x0002);smiWrite(0,2,0xc203);smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);break;
		case 0x0a:	smiWrite(0,31,0x0002);smiWrite(0,2,0xc203);smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);break;	
	}
	return 0;
}
int iolGiga_TestMode2_En(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01: smiWrite(0,31,0x0000);smiWrite(0,9,0x4000);break;
		//case 2: smiWrite(0,31,0x0005);smiWrite(0,5,0x8b86);smiWrite(0,6,0xe200);smiWrite(0,31,0x0007);smiWrite(0,30,0020);smiWrite(0,21,0x0108);
	}
	return 0;
}
int iolGiga_TestMode2_Dis(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01:	smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);break;
	}
	return 0;
}
int iolGiga_TestMode4_En(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,9,0x8000);break;
		case 0x02: 	smiWrite(0,31,0x0005);smiWrite(0,5,0x8b86);smiWrite(0,6,0xe200);smiWrite(0,31,0x0007);smiWrite(0,30,0x0020);smiWrite(0,21,0x0108);smiWrite(0,31,0x0000); //initial setting
								smiWrite(0,31,0x0000);smiWrite(0,9,0x8000);break;
		case 0x03: 	smiWrite(0,31,0x0000);smiWrite(0,9,0x8000);break;
		case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,9,0x8000);break;
	}
	return 0;
}
int iolGiga_TestMode4_Dis(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);break;
		case 0x02: 	smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);
								smiWrite(0,31,0x0005);smiWrite(0,5,0x8b86);smiWrite(0,6,0xe201);smiWrite(0,31,0x0007);smiWrite(0,30,0020);smiWrite(0,21,0x1108);smiWrite(0,31,0x0000);break;
		case 0x03: 	smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);break;
		case 0x0a:  smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);break;
	}
	return 0;
}
//chip type:
//01 -> 8211F
//02 -> 8211E(-VB)
//03 -> 8211DS
//04 -> 8201F-VA(8201FN-CG/8201FL-CG)
//05 -> 8201FR
//06 -> 8201F-VB(8201FN-VB/8201FL-VB/8201FR-VB)
//07 -> 8201FNI-VC
//08 -> 8201F-VD(8201FR-VD)
//09 -> 8201E
//0a -> 8211D
int iolMega_ChaA_En(uint16_t chiptype)
{
		switch(chiptype)
		{
			case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,24,0x2318);smiWrite(0,9,0x0000);smiWrite(0,0,0x2100);break;
			case 0x02: 	smiWrite(0,31,0x0005);smiWrite(0,5,0x8b86);smiWrite(0,6,0xe200);smiWrite(0,31,0x0007);smiWrite(0,30,0x0020);smiWrite(0,21,0x0108);smiWrite(0,31,0x0000); //initial setting
									smiWrite(0,31,0x0007);smiWrite(0,30,0x002f);smiWrite(0,23,0xd818);smiWrite(0,30,0x002d);smiWrite(0,24,0xf060);smiWrite(0,31,0x0000);smiWrite(0,16,0x00ae);/*phySwRST();*/break;
			case 0x03: 	smiWrite(0,23,0xa106);smiWrite(0,31,0x0007);smiWrite(0,30,0x002d);smiWrite(0,24,0xf030);smiWrite(0,31,0x0000);smiWrite(0,16,0x012e);break;
			case 0x04: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c2);smiWrite(0,0,0x2100); break;
			case 0x05: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c2);smiWrite(0,0,0x2100); break;
			case 0x06: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c2);smiWrite(0,0,0x2100); break;
			case 0x07: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c2);smiWrite(0,0,0x2100); break;
			case 0x08: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c2);smiWrite(0,0,0x2100); break;
			case 0x09: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);smiWrite(0,28,0x0000);smiWrite(0,31,0x0001);smiWrite(0,25,0x1f01);break;
			case 0x0a:	smiWrite(0,23,0xa106);smiWrite(0,31,0x0007);smiWrite(0,30,0x002d);smiWrite(0,24,0xf030);smiWrite(0,31,0x0000);smiWrite(0,16,0x012e);break; //same as 8211ds
		}
		return 0;
}
//chip type:
//01 -> 8211F
//02 -> 8211E(-VB)
//03 -> 8211DS
//04 -> 8201F-VA(8201FN-CG/8201FL-CG)
//05 -> 8201FR
//06 -> 8201F-VB(8201FN-VB/8201FL-VB/8201FR-VB)
//07 -> 8201FNI-VC
//08 -> 8201F-VD(8201FR-VD)
//09 -> 8201E
//0a -> 8211D
int iolMega_ChaB_En(uint16_t chiptype)
{
		switch(chiptype)
		{
			case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,24,0x2218);smiWrite(0,9,0x0000);smiWrite(0,0,0x2100);break;
			case 0x02: 	smiWrite(0,31,0x0005);smiWrite(0,5,0x8b86);smiWrite(0,6,0xe200);smiWrite(0,31,0x0007);smiWrite(0,30,0x0020);smiWrite(0,21,0x0108);smiWrite(0,31,0x0000); //initial setting
									smiWrite(0,31,0x0007);smiWrite(0,30,0x002f);smiWrite(0,23,0xd818);smiWrite(0,30,0x002d);smiWrite(0,24,0xf060);smiWrite(0,31,0x0000);smiWrite(0,16,0x008e);/*phySwRST();*/break;
			case 0x03: 	smiWrite(0,23,0xa106);smiWrite(0,31,0x0007);smiWrite(0,30,0x002d);smiWrite(0,24,0xf030);smiWrite(0,31,0x0000);smiWrite(0,16,0x010e);break;
			case 0x04: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c0);smiWrite(0,0,0x2100); break;
			case 0x05: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c0);smiWrite(0,0,0x2100); break;
			case 0x06: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c0);smiWrite(0,0,0x2100); break;
			case 0x07: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c0);smiWrite(0,0,0x2100); break;
			case 0x08: 	smiWrite(0,31,0x0004);smiWrite(0,16,0x4077);smiWrite(0,21,0xc5a0);smiWrite(0,31,0x0000);
									smiWrite(0,0,0x8000); smiWrite(0,24,0x0310);smiWrite(0,28,0x40c0);smiWrite(0,0,0x2100); break;
			case 0x09: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);smiWrite(0,28,0x0000);smiWrite(0,31,0x0001);smiWrite(0,25,0x1f00);break;
			case 0x0a:  smiWrite(0,23,0xa106);smiWrite(0,31,0x0007);smiWrite(0,30,0x002d);smiWrite(0,24,0xf030);smiWrite(0,31,0x0000);smiWrite(0,16,0x010e);break;
		}
		return 0;
}
void iolMega_MLT3_Dis(uint16_t chiptype)
{
	//to be fill by hw rst phy chipset
	phyHwRST();
}
//IOL TEST End********************//

//MP Register Loopback Begin******//
//chip type:
//01 -> 8211F
//02 -> 8211E(-VB)
//03 -> 8211DS
//04 -> 8201F-VA(8201FN-CG/8201FL-CG)
//05 -> 8201FR
//06 -> 8201F-VB(8201FN-VB/8201FL-VB/8201FR-VB)
//07 -> 8201FNI-VC
//08 -> 8201F-VD(8201FR-VD)
//09 -> 8201E
//0a ->	8211D
int lpTen_PCS_En(uint16_t chiptype)
{
		switch(chiptype)
		{
			case 0x01:	smiWrite(0,31,0x0000);smiWrite(0,0,0x8000);Delayms(25);smiWrite(0,0,0x4000);break;
			case 0x02: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x8000);Delayms(25);smiWrite(0,0,0x4001);break;
			case 0x03: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x4100);break;
			case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,0,0x4100);break;
			case 0x04:	smiWrite(0,31,0x0000);smiWrite(0,0,0x4100);smiWrite(0,31,0x0007);
									smiWrite(0,16,0x1ff8);//rmi input mode only
								//smiWrite(0,16,0x0ff8);//rmi output mode only
									smiWrite(0,31,0x0000);break;
			case 0x05:	smiWrite(0,31,0x0000);smiWrite(0,0,0x4100);smiWrite(0,31,0x0007);
									smiWrite(0,16,0x1ff8);//rmi input mode only
								//smiWrite(0,16,0x0ff8);//rmi output mode only
									smiWrite(0,31,0x0000);break;
			case 0x06:	smiWrite(0,31,0x0000);smiWrite(0,0,0x4100);smiWrite(0,31,0x0007);
									smiWrite(0,16,0x1ff8);//rmi input mode only
								//smiWrite(0,16,0x0ff8);//rmi output mode only
									smiWrite(0,31,0x0000);break;
		  case 0x07:	smiWrite(0,31,0x0000);smiWrite(0,0,0x4100);smiWrite(0,31,0x0007);
									smiWrite(0,16,0x1ff8);//rmi input mode only
								//smiWrite(0,16,0x0ff8);//rmi output mode only
									smiWrite(0,31,0x0000);break;
			case 0x08:	smiWrite(0,31,0x0000);smiWrite(0,0,0x4100);smiWrite(0,31,0x0007);
									smiWrite(0,16,0x1ff8);//rmi input mode only
								//smiWrite(0,16,0x0ff8);//rmi output mode only
									smiWrite(0,31,0x0000);break;
			case 0x09: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x4100);break;
		}
		return 0;
}
int lpTen_PCS_Dis(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x1040);break;
		case 0x02: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
		case 0x03:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
		case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
		case 0x04:	break;//to be fill by hw rst
		case 0x05:	break;//to be fill by hw rst
		case 0x06:	break;//to be fill by hw rst
		case 0x07:  break;//to be fill by hw rst
		case 0x08:  break;//to be fill by hw rst
		case 0x09:  break;//to be fill by hw rst
	}
	return 0;
}
//chip type:
//01 -> 8211F
//02 -> 8211E(-VB)
//03 -> 8211DS
//04 -> 8201F-VA(8201FN-CG/8201FL-CG)
//05 -> 8201FR
//06 -> 8201F-VB(8201FN-VB/8201FL-VB/8201FR-VB)
//07 -> 8201FNI-VC
//08 -> 8201F-VD(8201FR-VD)
//09 -> 8201E
//0a ->	8211D
int lpMega_PCS_En(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01:	smiWrite(0,31,0x0000);smiWrite(0,0,0x8000);Delayms(25);smiWrite(0,0,0x6000);break;
		case 0x02:	smiWrite(0,31,0x0000);smiWrite(0,0,0x8000);Delayms(25);smiWrite(0,0,0x6100);break;
		case 0x03:	smiWrite(0,31,0x0000);smiWrite(0,0,0x6100);break;
		case 0x0a:  smiWrite(0,31,0x0000);smiWrite(0,0,0x6100);break;
		case 0x04:	smiWrite(0,31,0x0000);smiWrite(0,0,0x6100);smiWrite(0,31,0x0007);
								smiWrite(0,16,0x1ff8);//rmi input mode only
							//smiWrite(0,16,0x0ff8);//rmi output mode only
								smiWrite(0,31,0x0000);break;
		case 0x05:	smiWrite(0,31,0x0000);smiWrite(0,0,0x6100);smiWrite(0,31,0x0007);
								smiWrite(0,16,0x1ff8);//rmi input mode only
							//smiWrite(0,16,0x0ff8);//rmi output mode only
								smiWrite(0,31,0x0000);break;
		case 0x06:	smiWrite(0,31,0x0000);smiWrite(0,0,0x6100);smiWrite(0,31,0x0007);
								smiWrite(0,16,0x1ff8);//rmi input mode only
							//smiWrite(0,16,0x0ff8);//rmi output mode only
								smiWrite(0,31,0x0000);break;
		case 0x07:	smiWrite(0,31,0x0000);smiWrite(0,0,0x6100);smiWrite(0,31,0x0007);
								smiWrite(0,16,0x1ff8);//rmi input mode only
							//smiWrite(0,16,0x0ff8);//rmi output mode only
								smiWrite(0,31,0x0000);break;
		case 0x08:	smiWrite(0,31,0x0000);smiWrite(0,0,0x6100);smiWrite(0,31,0x0007);
								smiWrite(0,16,0x1ff8);//rmi input mode only
							//smiWrite(0,16,0x0ff8);//rmi output mode only
								smiWrite(0,31,0x0000);break;
		case 0x09:	smiWrite(0,31,0x0000);smiWrite(0,0,0x6100);break;
	}
	return 0;
}
int lpMega_PCS_Dis(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1040);break;
		case 0x02:  smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
		case 0x03:  smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
		case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
		case 0x04:	break;//to be fill by hw rst
		case 0x05:	break;//to be fill by hw rst
		case 0x06:	break;//to be fill by hw rst
		case 0x07:	break;//to be fill by hw rst
		case 0x08:	break;//to be fill by hw rst
		case 0x09:	break;//to be fill by hw rst
	}	
	return 0;
}
//chip type:
//01 -> 8211F
//02 -> 8211E(-VB)
//03 -> 8211DS
//04 -> 8201F-VA(8201FN-CG/8201FL-CG)
//05 -> 8201FR
//06 -> 8201F-VB(8201FN-VB/8201FL-VB/8201FR-VB)
//07 -> 8201FNI-VC
//08 -> 8201F-VD(8201FR-VD)
//09 -> 8201E
//0a ->	8211D
int lpGiga_PCS_En(uint16_t chiptype)
{
		switch(chiptype)
		{
			case 0x01:	smiWrite(0,31,0x0000);smiWrite(0,0,0x8000);Delayms(25);smiWrite(0,0,0x4040);break;
			case 0x02:	smiWrite(0,31,0x0000);smiWrite(0,0,0x8000);Delayms(25);smiWrite(0,0,0x4140);break;
			case 0x03:	smiWrite(0,31,0x0000);smiWrite(0,0,0x4140);smiWrite(0,0,0x0042);break;
			case 0x0a: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x4140);smiWrite(0,0,0x0042);break;
		//case 0x04-0x09:	break;//8201 Series do not support giga pcs
		}
		return 0;
}

int lpGiga_PCS_Dis(uint16_t chiptype)
{
		switch(chiptype)
		{
			case 0x01:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1040);break;
			case 0x02:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
			case 0x03:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);smiWrite(0,20,0x8040);break;
			case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);smiWrite(0,20,0x8040);break;
		//case 0x04-0x09:	break;//8201 Series do not support giga pcs
		}
		return 0;
}

//chip type:
//01 -> 8211F
//02 -> 8211E(-VB)
//03 -> 8211DS
//04 -> 8201F-VA(8201FN-CG/8201FL-CG)
//05 -> 8201FR
//06 -> 8201F-VB(8201FN-VB/8201FL-VB/8201FR-VB)
//07 -> 8201FNI-VC
//08 -> 8201F-VD(8201FR-VD)
//09 -> 8201E
//0a ->	8211D
int lpTen_MDI_En(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x0100);break;
							//Option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break 	//wait for 4s link
		case 0x02:	smiWrite(0,31,0x0000);smiWrite(0,0,0x0100);break; //wait 100ms for link
							//Option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break	//wait for 4s link
		case 0x03:	smiWrite(0,31,0x0000);smiWrite(0,0,0x0100);break;
							//Option1
							//smiWrite(0,31,0x0000);smiWrite(0,0,0x8100);break;
							//Option2
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break	//wait for 4s link
		case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,0,0x0100);break;
							//Option1
							//smiWrite(0,31,0x0000);smiWrite(0,0,0x8100);break;
							//Option2
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break	//wait for 4s link
		case 0x04:	smiWrite(0,31,0x0000);smiWrite(0,0,0100);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break;	
		case 0x05:	smiWrite(0,31,0x0000);smiWrite(0,0,0100);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break;
		case 0x06:	smiWrite(0,31,0x0000);smiWrite(0,0,0100);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break;
		case 0x07:	smiWrite(0,31,0x0000);smiWrite(0,0,0100);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break;	
		case 0x08:	smiWrite(0,31,0x0000);smiWrite(0,0,0100);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break;	
		case 0x09:	smiWrite(0,31,0x0000);smiWrite(0,0,0100);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x0061);smiWrite(0,0,0x1200);break;			
	}
	return	0;
}
int lpTen_MDI_Dis(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x1040);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0200);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break;
		case 0x02: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0200);smiWrite(0,4,0x05e1);smiWrite(0,0,0x1200);break;
		case 0x03:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0300);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break;
		case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0300);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break;
		case 0x04:	smiWrite(0,31,0x0000);smiWrite(0,0,0x3100);break;
		case 0x05:	smiWrite(0,31,0x0000);smiWrite(0,0,0x3100);break;
		case 0x06:	smiWrite(0,31,0x0000);smiWrite(0,0,0x3100);break;
		case 0x07:	smiWrite(0,31,0x0000);smiWrite(0,0,0x3100);break;
		case 0x08:	smiWrite(0,31,0x0000);smiWrite(0,0,0x3100);break;
		case 0x09:	smiWrite(0,31,0x0000);smiWrite(0,0,0x3100);break;
		
	}
	return 0;
}
int lpMega_MDI_En(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break;	//wait 4s link
		case 0x02:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option 
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break;	//wait 4s link
		case 0x03:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break; //wait 4s link
		case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break; //wait 4s link	
		case 0x04:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break; //wait 4s link
		case 0x05:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break; //wait 4s link
		case 0x06:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break; //wait 4s link
		case 0x07:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break; //wait 4s link
		case 0x08:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break; //wait 4s link
		case 0x09:	smiWrite(0,31,0x0000);smiWrite(0,0,0x2100);break;	//wait 100ms link
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,4,0x01e1);smiWrite(0,0,0x1200);break; //wait 4s link		
	}
	return 0;
}
int lpMega_MDI_Dis(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01: 	smiWrite(0,31,0x0000);smiWrite(0,0,0x1040);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0200);smiWrite(0,0,0x1200);break;
		case 0x02:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0200);smiWrite(0,0,0x1200);break;
		case 0x03:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0300);smiWrite(0,0,0x1200);break;
		case 0x0a:	smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);break;
							//option
							//smiWrite(0,31,0x0000);smiWrite(0,9,0x0300);smiWrite(0,0,0x1200);break;	
		//case 0x04-0x09 do not support giga mode.
			
	}
	return 0;
}
int lpGiga_MDI_En(uint16_t chiptype)
{
	switch(chiptype)
	{
		case 0x01:		smiWrite(0,31,0x0a43);smiWrite(0,0,0x8000);Delayms(25);smiWrite(0,0,0x0140);smiWrite(0,0,0x2d18);break;
		case 0x02: 		smiWrite(0,31,0x0000);smiWrite(0,0,0x8000);Delayms(25);smiWrite(0,31,0x0007);smiWrite(0,30,0x0042);
									smiWrite(0,21,0x2500);smiWrite(0,30,0x0023);smiWrite(0,22,0x0006);smiWrite(0,31,0x0000);smiWrite(0,0,0x0140);
									smiWrite(0,26,0x0060);smiWrite(0,31,0x0007);smiWrite(0,30,0x002f);smiWrite(0,23,0xd820);smiWrite(0,31,0x0000);
									smiWrite(0,21,0x0206);smiWrite(0,23,0x2120);smiWrite(0,23,0x2160);break;
		case 0x03:		smiWrite(0,31,0x0001);smiWrite(0,3,0xff41);smiWrite(0,2,0xd720);smiWrite(0,1,0x0140);smiWrite(0,0,0x00bb);
									smiWrite(0,4,0xb800);smiWrite(0,4,0xb000);smiWrite(0,31,0x0007);smiWrite(0,30,0x0040);smiWrite(0,24,0x0008);
									smiWrite(0,31,0x0000);smiWrite(0,9,0x0300);smiWrite(0,26,0x0020);smiWrite(0,0,0x0140);smiWrite(0,23,0xa101);
									smiWrite(0,21,0x0200);smiWrite(0,23,0xa121);smiWrite(0,23,0xa161);smiWrite(0,0,0x8000);//Delayms(250); //200ms for link
		case 0x0a:		smiWrite(0,31,0x0001);smiWrite(0,3,0xff41);smiWrite(0,2,0xd720);smiWrite(0,1,0x0140);smiWrite(0,0,0x00bb);
									smiWrite(0,4,0xb800);smiWrite(0,4,0xb000);smiWrite(0,31,0x0007);smiWrite(0,30,0x0040);smiWrite(0,24,0x0008);
									smiWrite(0,31,0x0000);smiWrite(0,9,0x0300);smiWrite(0,26,0x0020);smiWrite(0,0,0x0140);smiWrite(0,23,0xa101);
									smiWrite(0,21,0x0200);smiWrite(0,23,0xa121);smiWrite(0,23,0xa161);smiWrite(0,0,0x8000);//Delayms(250); //200ms for link
		//case 0x04-0x09 do not support giga mode.									
	}
	return 0;
}
int lpGiga_MDI_Dis(uint16_t chiptype)
{
		switch(chiptype)
		{
			case 0x01:	smiWrite(0,31,0x0a43);
									smiWrite(0,24,0x2118); //for RGMII mode;
								//smiWrite(0,24,0x2198); //for GMII	mode;
									smiWrite(0,0,0x1040);break;
			case 0x02:	smiWrite(0,31,0x0000);smiWrite(0,0,0x8000);smiWrite(0,31,0x0007);smiWrite(0,30,0x0042);smiWrite(0,21,0x0500);
									smiWrite(0,31,0x0000);smiWrite(0,0,0x1140);smiWrite(0,26,0x0040);smiWrite(0,31,0x0007);smiWrite(0,30,0x002f);
									smiWrite(0,23,0xd88f);smiWrite(0,30,0x0023);smiWrite(0,22,0x0300);smiWrite(0,31,0x0000);smiWrite(0,21,0x1006);smiWrite(0,23,0x2100);break;
			case 0x03:	smiWrite(0,31,0x0001);smiWrite(0,3,0xdf41);smiWrite(0,2,0xdf20);smiWrite(0,1,0x0140);smiWrite(0,0,0x00bb);
									smiWrite(0,4,0xb800);smiWrite(0,4,0xb000);smiWrite(0,31,0x0000);smiWrite(0,26,0x0040);smiWrite(0,0,0x1140);
									smiWrite(0,21,0x1006);smiWrite(0,23,0x2100);break;
			case 0x0a:	smiWrite(0,31,0x0001);smiWrite(0,3,0xdf41);smiWrite(0,2,0xdf20);smiWrite(0,1,0x0140);smiWrite(0,0,0x00bb);
									smiWrite(0,4,0xb800);smiWrite(0,4,0xb000);smiWrite(0,31,0x0000);smiWrite(0,26,0x0040);smiWrite(0,0,0x1140);
									smiWrite(0,21,0x1006);smiWrite(0,23,0x2100);break;
			//case 0x04-0x09 do not support giga mode.			
		}
		return 0;
}
//*********************************************************MP Register Loopback End**********************************************************//
void acknowledge(uint8_t cmd,uint8_t option)
{
	uint8_t cmddata[3];
	//header
	cmddata[0]=0x01;
	cmddata[1]=cmd;
	cmddata[2]=option;
//	printf("0x%02X ",cmddata[0]);
//	printf("0x%02X ",cmddata[1]);
//	printf("0x%02X ",cmddata[2]);
	USB_SendData(cmddata,sizeof(cmddata));
}
int main(void)
{
	uint8_t data[64];
	uint8_t dumpdata[64];
	uint16_t rdata;
	uint16_t wdata;
	uint16_t arydata[12];
	uint32_t i=0,ret=0,j=0;
	Set_System();//系统时钟初始化
	USART_Configuration();//串口1初始化
	printf("\r\n*******************************************************************************");
	printf("\r\n************************STM32 SMI UART DEBUG***********************************");
	printf("\r\n");
	USB_Interrupts_Config();
	Set_USBClock();
	/* 配置USB D+ 线为全速模式 */
  USB_Cable_Config2 (ENABLE);			
	USB_Init();
	//以上是USB初始化完成了
	dataLED_CONFIG();
	smiInit();
	phyRST_CONFIG();
	while(1)
	{
		if(USB_Received_Flag)
			{
				USB_Received_Flag=0;
				ret = USB_GetData(data,sizeof(data));
				printf("usb get data %d byte data\n\r",ret);
				for(i=0;i<ret;i++){
					printf("0x%02X ",data[i]);
				}
				printf("\n\r");
				BlinkDataLed();
				switch(data[1])				
				{		
											//RST 01 hwrst/00 swrst
					case 0x00:	if(data[2] == 0x00) phyHwRST(); 
											else phySwRST();
											acknowledge(0x00,data[2]);
											break;
											//FW update TO DO.
					case 0x01:	break;
											//GeneralRW 00 read/01 write 
					case 0x02:	if(data[2] == 0x00)
												{
													if(data[6]<0x0b)
													{
														smiRead(data[3],data[4],&rdata);
														printf("0x%02X ",rdata);data[0] = ((rdata & 0xff00)>>8);data[1] = (rdata & 0x00ff);
														USB_SendData(data,sizeof(data));
													}
													else if(data[6] == 0x0b) //for 2.5G 8226 flow
													{
														smiWriteAddr_8226(data[3],data[5],((data[4] <<8) + data[7]));
														smiReadReg_8226(data[3],data[5],&rdata);
														printf("0x%02X ",rdata);data[0] = ((rdata & 0xff00)>>8);data[1] = (rdata & 0x00ff);
														USB_SendData(data,sizeof(data));}
													}
											else if(data[2] == 0x01)
												{
													if(data[8] < 0x0b)
													{
														wdata = (data[5] <<8) + data[6];
														smiWrite(data[3],data[4],wdata);
													}
													else if(data[8] ==0x0b) //for 2.5G 8226 flow
													{	
														wdata = (data[5] <<8) + data[6];
														smiWriteAddr_8226(data[3],data[7],((data[4] << 8) + data[9]));
														smiWriteReg_8226(data[3],data[7],wdata);
													}
													//
												}
											break;
												//set reg bit 0 or 1
					case 0x06:  if(data[2]==0x00) //setbit
												{
													if(data[7] == 0x0b)
															smiSetBit_8226(data[3],data[6],((data[4] <<8) + data[9]),data[5]);
												}
					
											else if(data[2] == 0x01) //reset bit
											{
												if(data[7] == 0x0b)
															smiResetBit_8226(data[3],data[6],((data[4] <<8) + data[9]),data[5]);
											}
											break;
											//IOLcmd;
					case 0x03:	if(data[2] == 0x01) 			iolMega_ChaA_En(data[3]);
											else if(data[2] == 0x02) 	iolMega_ChaB_En(data[3]);
											else if(data[2] == 0x03) 	iolGiga_TestMode1_En(data[3]);
											else if(data[2] == 0x04)	iolGiga_TestMode2_En(data[3]);
										//else if(data[2] == 0x05)	iolGiga_TestMode3_En(data[3]);
											else if(data[2] == 0x06)	iolGiga_TestMode1_En(data[3]);
											else if(data[2] == 0x07)	iolGiga_TestMode1_Dis(data[3]);
											else if(data[2] == 0x08)	iolGiga_TestMode2_Dis(data[3]);
										//else if(data[2] == 0x07)	iolGiga_TestMode3_Dis(data[3]);
											else if(data[2] == 0x0a)	iolGiga_TestMode4_Dis(data[3]);
											else if(data[2] == 0x0b)	iolMega_MLT3_Dis(data[3]);
											acknowledge(0x03,data[2]);
											break;
										//lOOPBACK cmd
				 case 0x04:	if(data[2] == 0x01)					lpTen_PCS_En(data[3]);
										else if(data[2] == 0x02)		lpMega_PCS_En(data[3]);
										else if(data[2] == 0x03)		lpGiga_PCS_En(data[3]);	
										else if(data[2] == 0x04)		lpTen_MDI_En(data[3]);
										else if(data[2] == 0x05)		lpMega_MDI_En(data[3]);
										else if(data[2] == 0x06)		lpGiga_MDI_En(data[3]);
										else if(data[2] == 0x07)		lpTen_PCS_Dis(data[3]);
										else if(data[2] == 0x08)		lpMega_PCS_Dis(data[3]);
										else if(data[2] == 0x09)		lpGiga_PCS_Dis(data[3]);
										else if(data[2] == 0x0a)		lpTen_MDI_Dis(data[3]);
										else if(data[2] == 0x0b)		lpMega_MDI_Dis(data[3]);
										else if(data[2] == 0x0c)		lpGiga_MDI_Dis(data[3]);
										acknowledge(0x04,data[2]);
										break;
										//reg0 -reg 11 dump
				case 0x05:	smiWrite(0,31,0x0000); //switch to page0
										for(i=0;i<0xb;i++) 
										{
											smiRead(0,data[2+i],&arydata[i]);
											printf("0x%02X ",arydata[i]);
										}
										data[0]=(arydata[0] & 0xff00) >>8;
										data[1]=(arydata[0] & 0x00ff);
										data[2]=(arydata[1] & 0xff00) >>8;
										data[3]=(arydata[1] & 0x00ff);
										data[4]=(arydata[2] & 0xff00) >>8;
										data[5]=(arydata[2] & 0x00ff);
										for(i=0,j=0;i<0xb;i++)
										{
												dumpdata[j++]=(arydata[i] & 0xff00) >>8;
												dumpdata[j++]=(arydata[i] & 0x00ff);
										}
										USB_SendData(dumpdata,sizeof(dumpdata));
										//acknowledge(0x05,0x01);
										break;
										
				}
			}
		}
	}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  报告在检查参数发生错误时的源文件名和错误行数
  * @param  file 源文件名
  * @param  line 错误所在行数 
  * @retval None
  */
void assert_failed(uint8_t* file, uint32_t line)
{
    /* 用户可以增加自己的代码用于报告错误的文件名和所在行数,
       例如：printf("错误参数值: 文件名 %s 在 %d行\r\n", file, line) */

    /* 无限循环 */
    while (1)
    {
    }
}
#endif

/*********************************END OF FILE**********************************/
