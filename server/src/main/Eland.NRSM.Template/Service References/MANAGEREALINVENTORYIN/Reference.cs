﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eland.NRSM.Template.MANAGEREALINVENTORYIN {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://sap.com/xi/SAPGlobal/Global")]
    public partial class StandardMessageFault : object, System.ComponentModel.INotifyPropertyChanged {
        
        private ExchangeFaultData standardField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public ExchangeFaultData standard {
            get {
                return this.standardField;
            }
            set {
                this.standardField = value;
                this.RaisePropertyChanged("standard");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/SD")]
    public partial class ExchangeFaultData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string faultTextField;
        
        private string faultUrlField;
        
        private ExchangeLogData[] faultDetailField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string faultText {
            get {
                return this.faultTextField;
            }
            set {
                this.faultTextField = value;
                this.RaisePropertyChanged("faultText");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string faultUrl {
            get {
                return this.faultUrlField;
            }
            set {
                this.faultUrlField = value;
                this.RaisePropertyChanged("faultUrl");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("faultDetail", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public ExchangeLogData[] faultDetail {
            get {
                return this.faultDetailField;
            }
            set {
                this.faultDetailField = value;
                this.RaisePropertyChanged("faultDetail");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/SD")]
    public partial class ExchangeLogData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string severityField;
        
        private string textField;
        
        private string urlField;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string severity {
            get {
                return this.severityField;
            }
            set {
                this.severityField = value;
                this.RaisePropertyChanged("severity");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
                this.RaisePropertyChanged("text");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
                this.RaisePropertyChanged("url");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/MOB")]
    public partial class RealInventoryResponse_sync : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mSGField;
        
        private string wERKSField;
        
        private string mATNRField;
        
        private string mAKTXField;
        
        private decimal lABSTField;
        
        private decimal rLABSTField;
        
        private string xSTATField;
        
        private System.DateTime xDATSField;
        
        private System.DateTime xTIMSField;
        
        private string flagField;
        
        private string returnMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string MSG {
            get {
                return this.mSGField;
            }
            set {
                this.mSGField = value;
                this.RaisePropertyChanged("MSG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string WERKS {
            get {
                return this.wERKSField;
            }
            set {
                this.wERKSField = value;
                this.RaisePropertyChanged("WERKS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string MAKTX {
            get {
                return this.mAKTXField;
            }
            set {
                this.mAKTXField = value;
                this.RaisePropertyChanged("MAKTX");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public decimal LABST {
            get {
                return this.lABSTField;
            }
            set {
                this.lABSTField = value;
                this.RaisePropertyChanged("LABST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public decimal RLABST {
            get {
                return this.rLABSTField;
            }
            set {
                this.rLABSTField = value;
                this.RaisePropertyChanged("RLABST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string XSTAT {
            get {
                return this.xSTATField;
            }
            set {
                this.xSTATField = value;
                this.RaisePropertyChanged("XSTAT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=7)]
        public System.DateTime XDATS {
            get {
                return this.xDATSField;
            }
            set {
                this.xDATSField = value;
                this.RaisePropertyChanged("XDATS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="time", Order=8)]
        public System.DateTime XTIMS {
            get {
                return this.xTIMSField;
            }
            set {
                this.xTIMSField = value;
                this.RaisePropertyChanged("XTIMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public string Flag {
            get {
                return this.flagField;
            }
            set {
                this.flagField = value;
                this.RaisePropertyChanged("Flag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=10)]
        public string ReturnMessage {
            get {
                return this.returnMessageField;
            }
            set {
                this.returnMessageField = value;
                this.RaisePropertyChanged("ReturnMessage");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/MOB")]
    public partial class RealInventoryQuery_sync : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string wERKSField;
        
        private string mATNRField;
        
        private decimal lABSTField;
        
        private decimal rLABSTField;
        
        private string mODEField;
        
        private string uNAMEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string WERKS {
            get {
                return this.wERKSField;
            }
            set {
                this.wERKSField = value;
                this.RaisePropertyChanged("WERKS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public decimal LABST {
            get {
                return this.lABSTField;
            }
            set {
                this.lABSTField = value;
                this.RaisePropertyChanged("LABST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public decimal RLABST {
            get {
                return this.rLABSTField;
            }
            set {
                this.rLABSTField = value;
                this.RaisePropertyChanged("RLABST");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string MODE {
            get {
                return this.mODEField;
            }
            set {
                this.mODEField = value;
                this.RaisePropertyChanged("MODE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string UNAME {
            get {
                return this.uNAMEField;
            }
            set {
                this.uNAMEField = value;
                this.RaisePropertyChanged("UNAME");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://eland.co.kr/KRERP/MOB", ConfigurationName="MANAGEREALINVENTORYIN.ManageRealInventoryIn")]
    public interface ManageRealInventoryIn {
        
        // CODEGEN: 操作 RealInventoryQueryResponse_In 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(Eland.NRSM.Template.MANAGEREALINVENTORYIN.StandardMessageFault), Action="", Name="StandardMessageFault", Namespace="http://sap.com/xi/SAPGlobal/Global")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InResponse RealInventoryQueryResponse_In(Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InResponse> RealInventoryQueryResponse_InAsync(Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RealInventoryQueryResponse_InRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://eland.co.kr/KRERP/MOB", Order=0)]
        public Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQuery_sync RealInventoryQuery_sync;
        
        public RealInventoryQueryResponse_InRequest() {
        }
        
        public RealInventoryQueryResponse_InRequest(Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQuery_sync RealInventoryQuery_sync) {
            this.RealInventoryQuery_sync = RealInventoryQuery_sync;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RealInventoryQueryResponse_InResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://eland.co.kr/KRERP/MOB", Order=0)]
        public Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryResponse_sync RealInventoryResponse_sync;
        
        public RealInventoryQueryResponse_InResponse() {
        }
        
        public RealInventoryQueryResponse_InResponse(Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryResponse_sync RealInventoryResponse_sync) {
            this.RealInventoryResponse_sync = RealInventoryResponse_sync;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ManageRealInventoryInChannel : Eland.NRSM.Template.MANAGEREALINVENTORYIN.ManageRealInventoryIn, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManageRealInventoryInClient : System.ServiceModel.ClientBase<Eland.NRSM.Template.MANAGEREALINVENTORYIN.ManageRealInventoryIn>, Eland.NRSM.Template.MANAGEREALINVENTORYIN.ManageRealInventoryIn {
        
        public ManageRealInventoryInClient() {
        }
        
        public ManageRealInventoryInClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManageRealInventoryInClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManageRealInventoryInClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManageRealInventoryInClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InResponse Eland.NRSM.Template.MANAGEREALINVENTORYIN.ManageRealInventoryIn.RealInventoryQueryResponse_In(Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InRequest request) {
            return base.Channel.RealInventoryQueryResponse_In(request);
        }
        
        public Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryResponse_sync RealInventoryQueryResponse_In(Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQuery_sync RealInventoryQuery_sync) {
            Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InRequest inValue = new Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InRequest();
            inValue.RealInventoryQuery_sync = RealInventoryQuery_sync;
            Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InResponse retVal = ((Eland.NRSM.Template.MANAGEREALINVENTORYIN.ManageRealInventoryIn)(this)).RealInventoryQueryResponse_In(inValue);
            return retVal.RealInventoryResponse_sync;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InResponse> Eland.NRSM.Template.MANAGEREALINVENTORYIN.ManageRealInventoryIn.RealInventoryQueryResponse_InAsync(Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InRequest request) {
            return base.Channel.RealInventoryQueryResponse_InAsync(request);
        }
        
        public System.Threading.Tasks.Task<Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InResponse> RealInventoryQueryResponse_InAsync(Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQuery_sync RealInventoryQuery_sync) {
            Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InRequest inValue = new Eland.NRSM.Template.MANAGEREALINVENTORYIN.RealInventoryQueryResponse_InRequest();
            inValue.RealInventoryQuery_sync = RealInventoryQuery_sync;
            return ((Eland.NRSM.Template.MANAGEREALINVENTORYIN.ManageRealInventoryIn)(this)).RealInventoryQueryResponse_InAsync(inValue);
        }
    }
}