//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by Web Services Description Language Utility
//Mono Framework v4.0.30319.42000
//


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="ServizioNumbersSoap", Namespace="http://tempuri.org/")]
public partial class ServizioNumbers : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback getSolutionsbyGridOperationCompleted;
    
    private System.Threading.SendOrPostCallback getGridOperationCompleted;
    
    private System.Threading.SendOrPostCallback getUserOperationCompleted;
    
    private System.Threading.SendOrPostCallback setUsersOperationCompleted;
    
    private System.Threading.SendOrPostCallback updUserScore1OperationCompleted;
    
    /// <remarks/>
    public ServizioNumbers() {
        this.Url = "http://numbers.jemaka.it/NumberService.asmx";
    }
    
    /// <remarks/>
    public event getSolutionsbyGridCompletedEventHandler getSolutionsbyGridCompleted;
    
    /// <remarks/>
    public event getGridCompletedEventHandler getGridCompleted;
    
    /// <remarks/>
    public event getUserCompletedEventHandler getUserCompleted;
    
    /// <remarks/>
    public event setUsersCompletedEventHandler setUsersCompleted;
    
    /// <remarks/>
    public event updUserScore1CompletedEventHandler updUserScore1Completed;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getSolutionsbyGrid", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public Solutions[] getSolutionsbyGrid(int idGrid) {
        object[] results = this.Invoke("getSolutionsbyGrid", new object[] {
                    idGrid});
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
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public Users getUser(string uuid) {
        object[] results = this.Invoke("getUser", new object[] {
                    uuid});
        return ((Users)(results[0]));
    }
    
    /// <remarks/>
    public void getUserAsync(string uuid) {
        this.getUserAsync(uuid, null);
    }
    
    /// <remarks/>
    public void getUserAsync(string uuid, object userState) {
        if ((this.getUserOperationCompleted == null)) {
            this.getUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetUserOperationCompleted);
        }
        this.InvokeAsync("getUser", new object[] {
                    uuid}, this.getUserOperationCompleted, userState);
    }
    
    private void OngetUserOperationCompleted(object arg) {
        if ((this.getUserCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.getUserCompleted(this, new getUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/setUsers", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string setUsers(Users u) {
        object[] results = this.Invoke("setUsers", new object[] {
                    u});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void setUsersAsync(Users u) {
        this.setUsersAsync(u, null);
    }
    
    /// <remarks/>
    public void setUsersAsync(Users u, object userState) {
        if ((this.setUsersOperationCompleted == null)) {
            this.setUsersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsetUsersOperationCompleted);
        }
        this.InvokeAsync("setUsers", new object[] {
                    u}, this.setUsersOperationCompleted, userState);
    }
    
    private void OnsetUsersOperationCompleted(object arg) {
        if ((this.setUsersCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.setUsersCompleted(this, new setUsersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/updUserScore1", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void updUserScore1(int id_user, float score1) {
        this.Invoke("updUserScore1", new object[] {
                    id_user,
                    score1});
    }
    
    /// <remarks/>
    public void updUserScore1Async(int id_user, float score1) {
        this.updUserScore1Async(id_user, score1, null);
    }
    
    /// <remarks/>
    public void updUserScore1Async(int id_user, float score1, object userState) {
        if ((this.updUserScore1OperationCompleted == null)) {
            this.updUserScore1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdUserScore1OperationCompleted);
        }
        this.InvokeAsync("updUserScore1", new object[] {
                    id_user,
                    score1}, this.updUserScore1OperationCompleted, userState);
    }
    
    private void OnupdUserScore1OperationCompleted(object arg) {
        if ((this.updUserScore1Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.updUserScore1Completed(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
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
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
public partial class Users {
    
    private int id_userField;
    
    private string nicknameField;
    
    private string imeiField;
    
    private string uuidField;
    
    private System.DateTime data_setupField;
    
    private string emailField;
    
    private string service_idField;
    
    private string noteField;
    
    private float score1Field;
    
    private float score2Field;
    
    private float bonus1Field;
    
    private float bonus2Field;
    
    /// <remarks/>
    public int Id_user {
        get {
            return this.id_userField;
        }
        set {
            this.id_userField = value;
        }
    }
    
    /// <remarks/>
    public string Nickname {
        get {
            return this.nicknameField;
        }
        set {
            this.nicknameField = value;
        }
    }
    
    /// <remarks/>
    public string Imei {
        get {
            return this.imeiField;
        }
        set {
            this.imeiField = value;
        }
    }
    
    /// <remarks/>
    public string Uuid {
        get {
            return this.uuidField;
        }
        set {
            this.uuidField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime Data_setup {
        get {
            return this.data_setupField;
        }
        set {
            this.data_setupField = value;
        }
    }
    
    /// <remarks/>
    public string Email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
    
    /// <remarks/>
    public string Service_id {
        get {
            return this.service_idField;
        }
        set {
            this.service_idField = value;
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
    
    /// <remarks/>
    public float Score1 {
        get {
            return this.score1Field;
        }
        set {
            this.score1Field = value;
        }
    }
    
    /// <remarks/>
    public float Score2 {
        get {
            return this.score2Field;
        }
        set {
            this.score2Field = value;
        }
    }
    
    /// <remarks/>
    public float Bonus1 {
        get {
            return this.bonus1Field;
        }
        set {
            this.bonus1Field = value;
        }
    }
    
    /// <remarks/>
    public float Bonus2 {
        get {
            return this.bonus2Field;
        }
        set {
            this.bonus2Field = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
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
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void getSolutionsbyGridCompletedEventHandler(object sender, getSolutionsbyGridCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
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
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void getGridCompletedEventHandler(object sender, getGridCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
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

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void getUserCompletedEventHandler(object sender, getUserCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class getUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal getUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public Users Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((Users)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void setUsersCompletedEventHandler(object sender, setUsersCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class setUsersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal setUsersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void updUserScore1CompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
