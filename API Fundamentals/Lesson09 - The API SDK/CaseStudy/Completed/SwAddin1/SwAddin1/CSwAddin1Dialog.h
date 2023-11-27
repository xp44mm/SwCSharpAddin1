#pragma once


// CSwAddin1Dialog dialog

class CSwAddin1Dialog : public CDialog
{
	DECLARE_DYNAMIC(CSwAddin1Dialog)

public:
	CSwAddin1Dialog(CWnd* pParent = NULL);   // standard constructor
	virtual ~CSwAddin1Dialog();

// Dialog Data
	enum { IDD = IDD_CSwAddin1Dialog };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
};
