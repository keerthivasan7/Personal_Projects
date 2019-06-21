#pragma once
#include"Enum.h"

class CDispense
{
public:
	CDispense();
	~CDispense();
public:
	int Fill(int iQuanity);
	int Dispense(int iQuanity);
	void Set(DispenseType eObj);
	DispenseType GetDispenserType();
	int GetCurrentLevel();
private:
	int m_iMaxLevel;
	int m_iCurrentLevel;
	DispenseType m_DispenseType;
};

