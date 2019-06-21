#include "Dispense.h"

CDispense::CDispense()
{
	m_iMaxLevel = 300;
	m_iCurrentLevel = 0;
}

CDispense::~CDispense()
{
}

int CDispense::Fill(int iQuanity)
{
	if ((m_iCurrentLevel + iQuanity) <= m_iMaxLevel)
	{
		m_iCurrentLevel += iQuanity;
		return 1;
	}
	else if ((m_iCurrentLevel + iQuanity) >= m_iMaxLevel)
	{
	    if (m_iCurrentLevel == m_iMaxLevel)
	    {
		return -1;
	    }
		while (m_iCurrentLevel != m_iMaxLevel)
		{
			m_iCurrentLevel++;
			iQuanity--;
		}
		return iQuanity;
	}
}

int CDispense::Dispense(int iQuanity)
{
	if (iQuanity <= m_iCurrentLevel)
	{
		m_iCurrentLevel -= iQuanity;
		return 1;
	}
	else
	{
		return -1;
	}
}

void CDispense::Set(DispenseType eObj)
{
	m_DispenseType = eObj;
}

DispenseType CDispense::GetDispenserType()
{
	return m_DispenseType;
}

int CDispense::GetCurrentLevel()
{
	return m_iCurrentLevel;
}
