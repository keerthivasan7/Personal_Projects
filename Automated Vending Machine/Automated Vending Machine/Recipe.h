#pragma once
#include<vector>
#include<iostream>
#include "Ingradients.h"
#include "Enum.h"
using namespace std;

class CRecipe
{
public:
	CRecipe();
	CRecipe(UserChoice eobj);
	~CRecipe();
public:
	void AddIngradients(CIngradients *iObj);
	vector<CIngradients*> GetIngradients();
	UserChoice GetReceipe();
	int GetIngradientCount();
private:
	vector<CIngradients*> pRecipe;
    UserChoice m_RecipeName;
};

