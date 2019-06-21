#include "Ingradients.h"


CIngradients::CIngradients()
{

}

CIngradients::~CIngradients()
{
}

void CIngradients::Add(DispenseType eObj, int Quanity)
{
	m_DispenserType = eObj;
	m_Quanity = Quanity;
}

DispenseType CIngradients::GetDispenserType()
{
	return m_DispenserType;
}

int CIngradients::GetQuanity()
{
	return m_Quanity;
}
