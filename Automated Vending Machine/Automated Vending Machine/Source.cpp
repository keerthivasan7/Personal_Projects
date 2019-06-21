#include<iostream>
#include "Enum.h"
#include "VendingMachine.h"
#include "Dispense.h"
#include "Ingradients.h"
#include "Recipe.h"
using namespace std;

void Menu();
void MainMenu();
void MenuAdmin();
void FillMenu();
void AdminMenu(CVendingMachine &vObj);
void UserOptions(CVendingMachine &vObj);
void DisplayIngradientsLevel(CVendingMachine& vObj);

void MakeProducts(UserChoice eObj, CVendingMachine& vObj)
{
	switch (eObj)
	{
	case UserChoice::eStrongTea:
	{
		CRecipe *prtObj = new CRecipe(UserChoice::eStrongTea);
		CIngradients *pitObj = new CIngradients();
		pitObj->Add(DispenseType::Tea, 10);
		prtObj->AddIngradients(pitObj);
		CIngradients *pimObj = new CIngradients();
		pimObj->Add(DispenseType::Milk, 30);
		prtObj->AddIngradients(pimObj);
		CIngradients *piwObj = new CIngradients();
		piwObj->Add(DispenseType::Water, 30);
		prtObj->AddIngradients(piwObj);
		vObj.AddRecipe(prtObj);
		break;
	}

	case UserChoice::eStrongCoffee:
	{
		CRecipe *prcObj = new CRecipe(UserChoice::eStrongCoffee);
		CIngradients *itObj = new CIngradients();
		itObj->Add(DispenseType::Coffee, 10);
		prcObj->AddIngradients(itObj);
		CIngradients *imObj = new CIngradients();
		imObj->Add(DispenseType::Milk, 30);
		prcObj->AddIngradients(imObj);
		CIngradients *iwObj = new CIngradients();
		iwObj->Add(DispenseType::Water, 30);
		prcObj->AddIngradients(iwObj);
		vObj.AddRecipe(prcObj);
		break;
	}
	case UserChoice::eMilk:
	{
		CRecipe *prmObj = new CRecipe(UserChoice::eMilk);
		CIngradients *imObj = new CIngradients();
		imObj->Add(DispenseType::Milk, 30);
		prmObj->AddIngradients(imObj);
		CIngradients *iwObj = new CIngradients();
		iwObj->Add(DispenseType::Water, 30);
		prmObj->AddIngradients(iwObj);
		vObj.AddRecipe(prmObj);
		break;
	}
	case UserChoice::eWater:
	{
		CRecipe *prwObj = new CRecipe(UserChoice::eWater);
		CIngradients *iwObj = new CIngradients();
		iwObj->Add(DispenseType::Water, 30);
		prwObj->AddIngradients(iwObj);
		vObj.AddRecipe(prwObj);
		break;
	}
	}
}

void MakeDispenser(CVendingMachine &vObj, DispenseType eObj)
{
	CDispense *pdObj = new CDispense();
	pdObj->Set(eObj);
	vObj.AddDispenser(pdObj);
}

void MakeMachine(CVendingMachine &vObj)
{
	MakeDispenser(vObj, DispenseType::Tea);
	MakeDispenser(vObj, DispenseType::Coffee);
	MakeDispenser(vObj, DispenseType::Milk);
	MakeDispenser(vObj, DispenseType::Water);
	MakeProducts(UserChoice::eStrongTea, vObj);
	MakeProducts(UserChoice::eStrongCoffee, vObj);
	MakeProducts(UserChoice::eMilk, vObj);
	MakeProducts(UserChoice::eWater, vObj);
}

bool FillDispenser(CVendingMachine &vObj, DispenseType eObj, int iInput1)
{
	CDispense *pdtObj = vObj.IsDispencerAvaliable(eObj);
	if (pdtObj != nullptr)
	{
		int m_iTemp = pdtObj->Fill(iInput1);
		if (m_iTemp == -1)
		{
			cout << "\n*****OverFlow*****\n";
			return false;
		}
		else if (m_iTemp == 1)
			return true;
		else
			cout << "->After Filling "<<pdtObj->GetCurrentLevel() <<" Amount the dispenser is full\n" << "->Remaining Amount: " << m_iTemp;
	}
}

int main()
{
	CVendingMachine vObj;
	MakeMachine(vObj);
	cout << "********* WELCOME TO VENDING MACHINE ***********\n";
	for (;;)
	{
		MainMenu();
		int iInput;
		cin >> iInput;
		if (iInput == 1)
		{
			AdminMenu(vObj);
		}
		else if (iInput == 2)
		{
			UserOptions(vObj);
		}
		else
		{
			exit(0);
		}
	}
	system("pause");
	return 0;
}

void DisplayIngradientsLevel(CVendingMachine& vObj)
{
	vector<CDispense*> pDispenser = vObj.GetDispenser();
	for (CDispense *dtObj : pDispenser)
	{
		if (dtObj->GetDispenserType() == 0)
		{
			cout << "Current Tea Level    (gram)  :" << dtObj->GetCurrentLevel() << endl;
		}
		if (dtObj->GetDispenserType() == 1)
		{
			cout << "Current Coffee Level (gram)  :" << dtObj->GetCurrentLevel() << endl;
		}
		if (dtObj->GetDispenserType() == 2)
		{
			cout << "Current Milk Level   (mL)    :" << dtObj->GetCurrentLevel() << endl;
		}
		if (dtObj->GetDispenserType() == 3)
		{
			cout << "Current Water Level  (mL)    :" << dtObj->GetCurrentLevel() << endl;
		}
	}

}

void MainMenu()
{
	cout << "\n************~MAIN MENU~**************\n";
	cout << "\n1. Admin\n2. User\n3. Exit\n\n";
}
void Menu()
{
	cout << "\n      MENU      \n";
	cout << "1. Strong Tea\n2. Strong Coffee\n3. Milk\n4. Water\n5. Go Back to Main Menu\n\n";
}
void MenuAdmin()
{
	cout << "\n--------------------------------\n";
	cout << "1. Check the Ingradients Level\n2. Fill the Ingradients\n3. Go Back to Main Menu\n";
}
void FillMenu()
{
	cout << "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
	cout << "-> Maximum capacity is 300\n";
	cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
	cout << "\n1. Fill Tea\n2. Fill Coffee\n3. Fill Milk\n4. Fill Water\n5. Go Back\n";
}


void AdminMenu(CVendingMachine &vObj)
{
	int iChoice;
	do {
		cout << "\nWELCOME ADMIN";
		MenuAdmin();
		cin >> iChoice;
		if (iChoice == 1)
		{
			cout << " \n";
			DisplayIngradientsLevel(vObj);
		}
		if (iChoice == 2)
		{
			int iChoice2;
			do {
				FillMenu();
				cin >> iChoice2;
				switch (iChoice2)
				{
				case 1:
					int iInput1;
					cout << "Enter the dispense Amount(gram): ";
					cin >> iInput1;
					if (FillDispenser(vObj, DispenseType::Tea, iInput1) == true)
					{
						cout << "\nTea Powder is Filled\n";
						break;
					}
					else
						break;
				case 2:
					int iInput2;
					cout << "Enter the dispense Amount(gram): ";
					cin >> iInput2;
					if (FillDispenser(vObj, DispenseType::Coffee, iInput2) == true)
					{
						cout << "\nCoffee Powder is Filled\n";
						break;
					}
					else
						break;
				case 3:
					int iInput3;
					cout << "Enter the dispense Amount(mL): ";
					cin >> iInput3;
					if (FillDispenser(vObj, DispenseType::Milk, iInput3) == true)
					{
						cout << "\nMilk is Filled\n";
						break;
					}
					else
						break;
				case 4:
					int iInput4;
					cout << "Enter the dispense Amount(mL): ";
					cin >> iInput4;
					if (FillDispenser(vObj, DispenseType::Water, iInput4) == true)
					{
						cout << "\nWater is filled\n";
						break;
					}
					else
						break;
				default:
					break;
				}
			} while (iChoice2 != 5);
		}
	} while (iChoice != 3);
}

void UserOptions(CVendingMachine &vObj)
{
	int iChoice;
	do
	{
		cout << "\n~WELCOME TO VENDING MACHINE~\n";
		Menu();
		cin >> iChoice;
		cout << " \n";
		switch (iChoice)
		{
		case 1:
			if (vObj.Dispense(UserChoice::eStrongTea) == true)
			{
						cout << "Tea   Dispenced\n";
						cout << "Milk  Dispenced\n";
						cout << "Water Dispenced\n";
			}
			else
				cout << "Sorry! Strong Tea Not Available\n";
			break;
		case 2:
			if (vObj.Dispense(UserChoice::eStrongCoffee) == true)
			{
						cout << "Coffee Dispenced\n";
						cout << "Milk   Dispenced\n";
						cout << "Water  Dispenced\n";
			}
			else
				cout << "Oops! Strong Coffee Not Available\n";
			break;
		case 3:
			if (vObj.Dispense(UserChoice::eMilk) == true)
			{
					cout << "Milk  Dispenced\n";
					cout << "Water Dispenced\n";
			}
			else
				cout << "Error! Milk Not Available\n";
			break;
		case 4:
			if (vObj.Dispense(UserChoice::eWater) == true)
			{
				cout << "Water Dispenced\n";
			}
			else
				cout << "Sorry! Water Not Available\n";
			break;

		default:
			break;
		}
	} while (iChoice != 5);
}