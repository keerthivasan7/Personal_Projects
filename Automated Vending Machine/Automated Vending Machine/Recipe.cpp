#include "Recipe.h"

CRecipe::CRecipe()
{
}

CRecipe::CRecipe(UserChoice eObj)
{
	m_RecipeName = eObj;
}

CRecipe::~CRecipe()
{
	for (CIngradients* prObj : pRecipe)
	{
		if (prObj != nullptr)
		{
			delete prObj;
			prObj = nullptr;
		}
	}
}

void CRecipe::AddIngradients(CIngradients *iObj)
{
	pRecipe.push_back(iObj);
}

vector<CIngradients*> CRecipe::GetIngradients()
{
	return pRecipe;
}

UserChoice CRecipe::GetReceipe()
{
	return m_RecipeName;
}

int CRecipe::GetIngradientCount()
{
	return pRecipe.size();
}


