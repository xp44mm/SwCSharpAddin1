// SwAddin1.h : Declaration of the CSwAddin1

#pragma once

#include "SwAddin1_i.h"

#include "resource.h"       // main symbols
#include <comsvcs.h>
#include <map>
class CSwDocument;
typedef std::map<IUnknown*, CSwDocument*> TMapIUnknownToDocument;

class CUserPropertyManagerPage;
class CBitmapHandler;

#define ID_SLDWORKS_EVENTS 0
#define MAIN_CMD_GROUP_ID 0 
#define MAIN_ITEM_ID1 0
#define MAIN_ITEM_ID2 1
#define FLYOUT_GROUP_ID 99
// CSwAddin1




class ATL_NO_VTABLE CSwAddin1 :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CSwAddin1, &CLSID_SwAddin1>,
	public IDispatchImpl<ISwAddin1, &IID_ISwAddin1, &LIBID_SwAddin1Lib, 1, 0>,
	public ISwAddin,
	public IDispEventImpl<ID_SLDWORKS_EVENTS, CSwAddin1, &__uuidof(DSldWorksEvents), &LIBID_SldWorks, ID_SLDWORKS_TLB_MAJOR, ID_SLDWORKS_TLB_MINOR> 
	{
	typedef IDispEventImpl<ID_SLDWORKS_EVENTS, CSwAddin1, &__uuidof(DSldWorksEvents), &LIBID_SldWorks, ID_SLDWORKS_TLB_MAJOR, ID_SLDWORKS_TLB_MINOR> CSldWorksEvents;

private:
	CComPtr<ISldWorks> iSwApp;
	CComPtr<ICommandManager> iCmdMgr;
	CComObject<CBitmapHandler> *iBmp;
	long addinID;
	long toolbarID;
	long m_swMajNum;
	long m_swMinNum;
//This mapping will contain references to all open Documents, and ensure 
//that we do not attempt to attach event handlers to an already opened doc. 
	TMapIUnknownToDocument openDocs;
	CComObject<CUserPropertyManagerPage> *userPropertyPage;

public:
	CSwAddin1()
	{
	}

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

	DECLARE_REGISTRY_RESOURCEID(IDR_SwAddin1)

	DECLARE_NOT_AGGREGATABLE(CSwAddin1)

	BEGIN_COM_MAP(CSwAddin1)
		COM_INTERFACE_ENTRY(ISwAddin1)
		COM_INTERFACE_ENTRY(IDispatch)
		COM_INTERFACE_ENTRY(ISwAddin)
	END_COM_MAP()


	// ISwAddin1
public:

	// ISwAddin Methods
public:
	CComPtr<ISldWorks> GetSldWorksPtr() { return iSwApp != NULL ? iSwApp : NULL; }
		//These methods will connect and disconnect this addin to the SolidWorks events
	VARIANT_BOOL AttachEventHandlers();
	VARIANT_BOOL DetachEventHandlers();
	//These methods will connect and disconnect this addin to the SolidWorks Model events
	VARIANT_BOOL AttachModelEventHandler(CComPtr<IModelDoc2> iModelDoc2);	
	VARIANT_BOOL DetachModelEventHandler(IUnknown *iUnk);
	HRESULT AttachEventsToAllDocuments();
TMapIUnknownToDocument OpenDocumentsTable() { return openDocs; }
	
	int GetSldWorksTlbMajor() {return (m_swMajNum >= ID_SLDWORKS_TLB_MAJOR ) ? m_swMajNum : 0;}
	int GetSldWorksTlbMinor() {return m_swMinNum;}

	void AddCommandManager();
	void RemoveCommandManager();
	bool CompareIDs(long * storedIDs, long storedSize, long * addinIDs, long addinSize);
	void AddPMP();
	void RemovePMP();
	BSTR GetCurrentFile();

		//Event Handlers
	//These are the methods that are called when certain SolidWorks events are fired
	STDMETHOD(OnDocChange)(void);
	STDMETHOD(OnModelDocChange)(void);
	STDMETHOD(OnDocLoad)(BSTR docTitle, BSTR docPath);
	STDMETHOD(OnFileNew)(LPDISPATCH newDoc, long docType, BSTR templateName);
	STDMETHOD(OnFileOpenPostNotify)(BSTR fileName);

	
	BEGIN_SINK_MAP(CSwAddin1)
		SINK_ENTRY_EX(ID_SLDWORKS_EVENTS, __uuidof(DSldWorksEvents), swAppActiveDocChangeNotify, OnDocChange)
		SINK_ENTRY_EX(ID_SLDWORKS_EVENTS, __uuidof(DSldWorksEvents), swAppDocumentLoadNotify, OnDocLoad)
		SINK_ENTRY_EX(ID_SLDWORKS_EVENTS, __uuidof(DSldWorksEvents), swAppFileNewNotify2, OnFileNew)
		SINK_ENTRY_EX(ID_SLDWORKS_EVENTS, __uuidof(DSldWorksEvents), swAppActiveModelDocChangeNotify, OnModelDocChange)
		SINK_ENTRY_EX(ID_SLDWORKS_EVENTS, __uuidof(DSldWorksEvents), swAppFileOpenPostNotify, OnFileOpenPostNotify)
	END_SINK_MAP( )
	
	// ISwAddin Methods
	//These are the methods inherited from the ISwAddin interface that 
	//need to be implemented in order to connect the addin to SolidWorks
public:
	STDMETHOD(ConnectToSW)(LPDISPATCH ThisSW, long Cookie, VARIANT_BOOL * IsConnected);
	STDMETHOD(DisconnectFromSW)(VARIANT_BOOL * IsDisconnected);


	STDMETHOD(ToolbarCallback0)(void);
	STDMETHOD(ToolbarEnable0)(long* status);
	STDMETHOD(FlyoutCallback)(void);
	STDMETHOD(FlyoutCallback0)(void);
	STDMETHOD(FlyoutCallback1)(void);
	STDMETHOD(FlyoutEnable0)(long* status);
	STDMETHOD(FlyoutEnableCallback0)(long* status);
	STDMETHOD(ShowPMP)(void);
	STDMETHOD(EnablePMP)(long* status);
};

OBJECT_ENTRY_AUTO(__uuidof(SwAddin1), CSwAddin1)
