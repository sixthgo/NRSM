﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eland.NRSM.Template.ZMANAGEFLOORCODEIN {
    
    
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/SD")]
    public partial class FloorCodeByIDConfirmationCheckResponseMessage_sync : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
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
    public partial class PlantID : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string schemeAgencyIDField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string schemeAgencyID {
            get {
                return this.schemeAgencyIDField;
            }
            set {
                this.schemeAgencyIDField = value;
                this.RaisePropertyChanged("schemeAgencyID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType="token")]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
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
    public partial class FloorCodeByIDConfirmationCheckQueryMessage_sync : object, System.ComponentModel.INotifyPropertyChanged {
        
        private PlantID plantIDField;
        
        private System.DateTime dateField;
        
        private bool dateFieldSpecified;
        
        private string floorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public PlantID PlantID {
            get {
                return this.plantIDField;
            }
            set {
                this.plantIDField = value;
                this.RaisePropertyChanged("PlantID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=1)]
        public System.DateTime Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
                this.RaisePropertyChanged("Date");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSpecified {
            get {
                return this.dateFieldSpecified;
            }
            set {
                this.dateFieldSpecified = value;
                this.RaisePropertyChanged("DateSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string Floor {
            get {
                return this.floorField;
            }
            set {
                this.floorField = value;
                this.RaisePropertyChanged("Floor");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://eland.co.kr/KRERP/SD", ConfigurationName="ZMANAGEFLOORCODEIN.ManageFloorCodeIn")]
    public interface ManageFloorCodeIn {
        
        // CODEGEN: Generating message contract since the operation FloorCodeByIDConfirmationResponse_In is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.StandardMessageFault), Action="", Name="StandardMessageFault", Namespace="http://sap.com/xi/SAPGlobal/Global")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InResponse FloorCodeByIDConfirmationResponse_In(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InResponse> FloorCodeByIDConfirmationResponse_InAsync(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InRequest request);
        
        // CODEGEN: Generating message contract since the operation FloorCodeSizeByIDQueryResponse_In is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.StandardMessageFault), Action="", Name="StandardMessageFault", Namespace="http://sap.com/xi/SAPGlobal/Global")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InResponse FloorCodeSizeByIDQueryResponse_In(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InResponse> FloorCodeSizeByIDQueryResponse_InAsync(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class FloorCodeByIDConfirmationResponse_InRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://eland.com/BPP/TEST", Order=0)]
        public Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationCheckQueryMessage_sync FloorCodeByIDConfirmationCheckQuery_sync;
        
        public FloorCodeByIDConfirmationResponse_InRequest() {
        }
        
        public FloorCodeByIDConfirmationResponse_InRequest(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationCheckQueryMessage_sync FloorCodeByIDConfirmationCheckQuery_sync) {
            this.FloorCodeByIDConfirmationCheckQuery_sync = FloorCodeByIDConfirmationCheckQuery_sync;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class FloorCodeByIDConfirmationResponse_InResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://eland.com/BPP/TEST", Order=0)]
        public Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationCheckResponseMessage_sync FloorCodeByIDConfirmationCheckResponse_sync;
        
        public FloorCodeByIDConfirmationResponse_InResponse() {
        }
        
        public FloorCodeByIDConfirmationResponse_InResponse(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationCheckResponseMessage_sync FloorCodeByIDConfirmationCheckResponse_sync) {
            this.FloorCodeByIDConfirmationCheckResponse_sync = FloorCodeByIDConfirmationCheckResponse_sync;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/SD")]
    public partial class FloorCodeSizeByIDQueryMassage_sync : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime dateField;
        
        private bool dateFieldSpecified;
        
        private string floorField;
        
        private PlantID plantIDField;
        
        private string companyCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=0)]
        public System.DateTime Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
                this.RaisePropertyChanged("Date");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateSpecified {
            get {
                return this.dateFieldSpecified;
            }
            set {
                this.dateFieldSpecified = value;
                this.RaisePropertyChanged("DateSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Floor {
            get {
                return this.floorField;
            }
            set {
                this.floorField = value;
                this.RaisePropertyChanged("Floor");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public PlantID PlantID {
            get {
                return this.plantIDField;
            }
            set {
                this.plantIDField = value;
                this.RaisePropertyChanged("PlantID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string CompanyCode {
            get {
                return this.companyCodeField;
            }
            set {
                this.companyCodeField = value;
                this.RaisePropertyChanged("CompanyCode");
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
    public partial class FloorCodeSizeByIDResponseMessage_sync : object, System.ComponentModel.INotifyPropertyChanged {
        
        private decimal spaceSizeField;
        
        private bool spaceSizeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public decimal SpaceSize {
            get {
                return this.spaceSizeField;
            }
            set {
                this.spaceSizeField = value;
                this.RaisePropertyChanged("SpaceSize");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpaceSizeSpecified {
            get {
                return this.spaceSizeFieldSpecified;
            }
            set {
                this.spaceSizeFieldSpecified = value;
                this.RaisePropertyChanged("SpaceSizeSpecified");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class FloorCodeSizeByIDQueryResponse_InRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://eland.com/BPP/TEST", Order=0)]
        public Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryMassage_sync FloorCodeSizeByIDQuery_sync;
        
        public FloorCodeSizeByIDQueryResponse_InRequest() {
        }
        
        public FloorCodeSizeByIDQueryResponse_InRequest(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryMassage_sync FloorCodeSizeByIDQuery_sync) {
            this.FloorCodeSizeByIDQuery_sync = FloorCodeSizeByIDQuery_sync;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class FloorCodeSizeByIDQueryResponse_InResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://eland.com/BPP/TEST", Order=0)]
        public Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDResponseMessage_sync FloorCodeSizeByIDResponse_sync;
        
        public FloorCodeSizeByIDQueryResponse_InResponse() {
        }
        
        public FloorCodeSizeByIDQueryResponse_InResponse(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDResponseMessage_sync FloorCodeSizeByIDResponse_sync) {
            this.FloorCodeSizeByIDResponse_sync = FloorCodeSizeByIDResponse_sync;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ManageFloorCodeInChannel : Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManageFloorCodeInClient : System.ServiceModel.ClientBase<Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn>, Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn {
        
        public ManageFloorCodeInClient() {
        }
        
        public ManageFloorCodeInClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManageFloorCodeInClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManageFloorCodeInClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManageFloorCodeInClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InResponse Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn.FloorCodeByIDConfirmationResponse_In(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InRequest request) {
            return base.Channel.FloorCodeByIDConfirmationResponse_In(request);
        }
        
        public Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationCheckResponseMessage_sync FloorCodeByIDConfirmationResponse_In(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationCheckQueryMessage_sync FloorCodeByIDConfirmationCheckQuery_sync) {
            Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InRequest inValue = new Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InRequest();
            inValue.FloorCodeByIDConfirmationCheckQuery_sync = FloorCodeByIDConfirmationCheckQuery_sync;
            Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InResponse retVal = ((Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn)(this)).FloorCodeByIDConfirmationResponse_In(inValue);
            return retVal.FloorCodeByIDConfirmationCheckResponse_sync;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InResponse> Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn.FloorCodeByIDConfirmationResponse_InAsync(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InRequest request) {
            return base.Channel.FloorCodeByIDConfirmationResponse_InAsync(request);
        }
        
        public System.Threading.Tasks.Task<Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InResponse> FloorCodeByIDConfirmationResponse_InAsync(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationCheckQueryMessage_sync FloorCodeByIDConfirmationCheckQuery_sync) {
            Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InRequest inValue = new Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeByIDConfirmationResponse_InRequest();
            inValue.FloorCodeByIDConfirmationCheckQuery_sync = FloorCodeByIDConfirmationCheckQuery_sync;
            return ((Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn)(this)).FloorCodeByIDConfirmationResponse_InAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InResponse Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn.FloorCodeSizeByIDQueryResponse_In(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InRequest request) {
            return base.Channel.FloorCodeSizeByIDQueryResponse_In(request);
        }
        
        public Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDResponseMessage_sync FloorCodeSizeByIDQueryResponse_In(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryMassage_sync FloorCodeSizeByIDQuery_sync) {
            Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InRequest inValue = new Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InRequest();
            inValue.FloorCodeSizeByIDQuery_sync = FloorCodeSizeByIDQuery_sync;
            Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InResponse retVal = ((Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn)(this)).FloorCodeSizeByIDQueryResponse_In(inValue);
            return retVal.FloorCodeSizeByIDResponse_sync;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InResponse> Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn.FloorCodeSizeByIDQueryResponse_InAsync(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InRequest request) {
            return base.Channel.FloorCodeSizeByIDQueryResponse_InAsync(request);
        }
        
        public System.Threading.Tasks.Task<Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InResponse> FloorCodeSizeByIDQueryResponse_InAsync(Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryMassage_sync FloorCodeSizeByIDQuery_sync) {
            Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InRequest inValue = new Eland.NRSM.Template.ZMANAGEFLOORCODEIN.FloorCodeSizeByIDQueryResponse_InRequest();
            inValue.FloorCodeSizeByIDQuery_sync = FloorCodeSizeByIDQuery_sync;
            return ((Eland.NRSM.Template.ZMANAGEFLOORCODEIN.ManageFloorCodeIn)(this)).FloorCodeSizeByIDQueryResponse_InAsync(inValue);
        }
    }
}
