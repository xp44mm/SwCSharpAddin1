// CSwAddin1Dialog.cpp : implementation file
//

#include "stdafx.h"


#include "CSwAddin1Dialog.h"


// CSwAddin1Dialog dialog

IMPLEMENT_DYNAMIC(CSwAddin1Dialog, CDialog)

CSwAddin1Dialog::CSwAddin1Dialog(CWnd* pParent /*=NULL*/)
	: CDialog(CSwAddin1Dialog::IDD, pParent)
{

}

CSwAddin1Dialog::~CSwAddin1Dialog()
{
}

void CSwAddin1Dialog::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CSwAddin1Dialog, CDialog)
END_MESSAGE_MAP()


// CSwAddin1Dialog message handlers
