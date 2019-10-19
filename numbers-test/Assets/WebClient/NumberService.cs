﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// Codice sorgente generato automaticamente da wsdl, versione=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="ServizioNumbersSoap", Namespace="http://tempuri.org/")]
public partial class ServizioNumbers : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback getSolutionsbyGridOperationCompleted;
    
    private System.Threading.SendOrPostCallback getGridOperationCompleted;
    
    /// <remarks/>
    public ServizioNumbers() {
        this.Url = "http://numbers.jemaka.it/NumberService.asmx";
    }
    
    /// <remarks/>
    public event getSolutionsbyGridCompletedEventHandler getSolutionsbyGridCompleted;
    
    /// <remarks/>
    public event getGridCompletedEventHandler getGridCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getSolutionsbyGrid", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public Solutions[] getSolutionsbyGrid(int idGrid) {
        object[] results = this.Invoke("getSolutionsbyGrid", new object[] {
                    idGrid});
        return ((Solutions[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetSolutionsbyGrid(int idGrid, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getSolutionsbyGrid", new object[] {
                    idGrid}, callback, asyncState);
    }
    
    /// <remarks/>
    public Solutions[] EndgetSolutionsbyGrid(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((Solutions[])(results[0]));
    }
    
    /// <remarks/>
    public void getSolutionsbyGridAsync(int idGrid) {
        this.getSolutionsbyGridAsync(idGrid, null);
    }
    
    /// <remarks/>
    public void getSolutionsbyGridAsync(int idGrid, object userState) {
        if ((this.getSolutionsbyGridOperationCompleted == null)) {
            this.getSolutionsbyGridOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetSolutionsbyGridOperationCompleted);
        }
        this.InvokeAsync("getSolutionsbyGrid", new object[] {
                    idGrid}, this.getSolutionsbyGridOperationCompleted, userState);
    }
    
    private void OngetSolutionsbyGridOperationCompleted(object arg) {
        if ((this.getSolutionsbyGridCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.getSolutionsbyGridCompleted(this, new getSolutionsbyGridCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getGrid", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public Grids getGrid() {
        object[] results = this.Invoke("getGrid", new object[0]);
        return ((Grids)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetGrid(System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getGrid", new object[0], callback, asyncState);
    }
    
    /// <remarks/>
    public Grids EndgetGrid(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((Grids)(results[0]));
    }
    
    /// <remarks/>
    public void getGridAsync() {
        this.getGridAsync(null);
    }
    
    /// <remarks/>
    public void getGridAsync(object userState) {
        if ((this.getGridOperationCompleted == null)) {
            this.getGridOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetGridOperationCompleted);
        }
        this.InvokeAsync("getGrid", new object[0], this.getGridOperationCompleted, userState);
    }
    
    private void OngetGridOperationCompleted(object arg) {
        if ((this.getGridCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.getGridCompleted(this, new getGridCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
public partial class Solutions {
    
    private int id_solutionField;
    
    private int id_gridField;
    
    private float numberField;
    
    private string sequenceField;
    
    private float difficultyField;
    
    private string noteField;
    
    /// <remarks/>
    public int Id_solution {
        get {
            return this.id_solutionField;
        }
        set {
            this.id_solutionField = value;
        }
    }
    
    /// <remarks/>
    public int Id_grid {
        get {
            return this.id_gridField;
        }
        set {
            this.id_gridField = value;
        }
    }
    
    /// <remarks/>
    public float Number {
        get {
            return this.numberField;
        }
        set {
            this.numberField = value;
        }
    }
    
    /// <remarks/>
    public string Sequence {
        get {
            return this.sequenceField;
        }
        set {
            this.sequenceField = value;
        }
    }
    
    /// <remarks/>
    public float Difficulty {
        get {
            return this.difficultyField;
        }
        set {
            this.difficultyField = value;
        }
    }
    
    /// <remarks/>
    public string Note {
        get {
            return this.noteField;
        }
        set {
            this.noteField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
public partial class Grids {
    
    private int id_gridField;
    
    private string itemField;
    
    private System.DateTime data_creationField;
    
    private float difficultyField;
    
    private Solutions solutionsField;
    
    /// <remarks/>
    public int Id_grid {
        get {
            return this.id_gridField;
        }
        set {
            this.id_gridField = value;
        }
    }
    
    /// <remarks/>
    public string Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime Data_creation {
        get {
            return this.data_creationField;
        }
        set {
            this.data_creationField = value;
        }
    }
    
    /// <remarks/>
    public float Difficulty {
        get {
            return this.difficultyField;
        }
        set {
            this.difficultyField = value;
        }
    }
    
    /// <remarks/>
    public Solutions Solutions {
        get {
            return this.solutionsField;
        }
        set {
            this.solutionsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
public delegate void getSolutionsbyGridCompletedEventHandler(object sender, getSolutionsbyGridCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class getSolutionsbyGridCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal getSolutionsbyGridCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public Solutions[] Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((Solutions[])(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
public delegate void getGridCompletedEventHandler(object sender, getGridCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class getGridCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal getGridCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public Grids Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((Grids)(this.results[0]));
        }
    }
}