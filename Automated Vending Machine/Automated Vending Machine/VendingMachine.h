#pragma once
#include"Enum.h"
#include "Recipe.h"
#include "Dispense.h"
class CVendingMachine
{
public:
	CVendingMachine();
	~CVendingMachine();
public:
	void AddDispenser(CDispense *dObj);
	void AddRecipe(CRecipe *rObj);
	bool Dispense(UserChoice eObj);
    vector<CDispense*>& GetDispenser();
	CDispense* IsDispencerAvaliable(DispenseType eObj);
private:
	CDispense* CheckDispenser(CIngradients *iObj);
	CRecipe* IsRecepieAvaliable(UserChoice eObj);
	int IngradientCount(UserChoice eObj);
	bool CheckIngradientCount(UserChoice eObj);
private:
	vector<CRecipe*> m_Recipes;
	vector<CDispense*> m_Dispenser;
};

