#include "VendingMachine.h"

CVendingMachine::CVendingMachine()
{
}

CVendingMachine::~CVendingMachine()
{
	for (CDispense *pdObj : m_Dispenser)
	{
		if (pdObj != nullptr)
		{
			delete pdObj;
			pdObj = nullptr;
		}
	}
	for (CRecipe *pdObj : m_Recipes)
	{
		if (pdObj != nullptr)
		{
			delete pdObj;
			pdObj = nullptr;
		}
	}
}

void CVendingMachine::AddDispenser(CDispense * dObj)
{
	m_Dispenser.push_back(dObj);
}

void CVendingMachine::AddRecipe(CRecipe * rObj)
{
	m_Recipes.push_back(rObj);
}

CRecipe* CVendingMachine::IsRecepieAvaliable(UserChoice eObj)
{
	for (CRecipe *rObj : m_Recipes)
	{
		if (rObj->GetReceipe() == eObj)
		{
			return rObj;
		}
	}
	return nullptr;
}

CDispense* CVendingMachine::IsDispencerAvaliable(DispenseType eObj)
{
	for (CDispense *dtObj : m_Dispenser)
	{
		if (dtObj->GetDispenserType() == eObj)
		{
			return dtObj;
		}
	}
	return nullptr;
}

bool CVendingMachine::Dispense(UserChoice eObj)
{
	CRecipe *rObj = IsRecepieAvaliable(eObj);
	if (rObj != nullptr && CheckIngradientCount(eObj) == true)
	{
		for (CIngradients *iObj : rObj->GetIngradients())
		{
			CDispense *dObj = CheckDispenser(iObj);
			if (dObj != nullptr)
			{
				dObj->Dispense((iObj->GetQuanity()));
			}
		}
		return true;
	}
	return false;
}

vector<CDispense*>& CVendingMachine::GetDispenser()
{
	return m_Dispenser;
}

int CVendingMachine::IngradientCount(UserChoice eObj)
{
	int iCount = 0;
	CRecipe *rObj = IsRecepieAvaliable(eObj);
	if (rObj->GetReceipe() == eObj)
	{
		for (CIngradients *iObj : rObj->GetIngradients())
		{
			for (CDispense *pObj : m_Dispenser)
			{
				if (pObj->GetDispenserType() == iObj->GetDispenserType())
				{
					if (rObj->GetReceipe() == eObj && iObj->GetQuanity() <= pObj->GetCurrentLevel())
					{
						iCount++;
					}
				}
			}
		}
	}
	return iCount;
}

CDispense * CVendingMachine::CheckDispenser(CIngradients *iObj)
{
	for (CDispense *dObj : m_Dispenser)
	{
		if ((dObj->GetDispenserType() == iObj->GetDispenserType()))
		{
			return dObj;
		}
	}
	return nullptr;
}

bool CVendingMachine::CheckIngradientCount(UserChoice eObj)
{
	CRecipe *rObj = IsRecepieAvaliable(eObj);
	if ((rObj->GetIngradientCount()) == IngradientCount(eObj) && (eObj == rObj->GetReceipe()))
	{
		return true;
	}
	return false;
}