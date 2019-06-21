#pragma once
#include<vector>
#include<iostream>
using namespace std;
#include "Enum.h"

class CIngradients
{
public:
	CIngradients();
	~CIngradients();
public:
	void Add(DispenseType eObj, int Quanity);
	DispenseType GetDispenserType();
	int GetQuanity();
private:
	vector <CIngradients *> pIngradients;
	DispenseType m_DispenserType;
	int m_Quanity;
};

