﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eland.NRSM.Template.MANAGESAVEMATERIALLABEL {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/MOB")]
    public partial class SaveMaterialLabelResponse_sync : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string flagField;
        
        private string returnMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/MOB")]
    public partial class MaterialPriceList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string wERKSField;
        
        private string mATNRField;
        
        private string mATNR1Field;
        
        private string eAN11Field;
        
        private string mAKTXField;
        
        private string pRICEField;
        
        private string kONWAField;
        
        private string mEINSField;
        
        private int gESMEField;
        
        private bool gESMEFieldSpecified;
        
        private System.DateTime dATABField;
        
        private bool dATABFieldSpecified;
        
        private string pERNOField;
        
        private string gUBUNField;
        
        private string gUBUN_TField;
        
        private string zFLAGField;
        
        private string zFLAG_TField;
        
        private int zCNTField;
        
        private bool zCNTFieldSpecified;
        
        private decimal sTPRCField;
        
        private bool sTPRCFieldSpecified;
        
        private decimal tOTALField;
        
        private bool tOTALFieldSpecified;
        
        private decimal lABSTField;
        
        private bool lABSTFieldSpecified;
        
        private decimal lABST_1Field;
        
        private bool lABST_1FieldSpecified;
        
        private decimal tOQTYField;
        
        private bool tOQTYFieldSpecified;
        
        private string nOCTLField;
        
        private string zRSUMField;
        
        private string bISMTField;
        
        private string eKGRPField;
        
        private decimal dPTPRField;
        
        private bool dPTPRFieldSpecified;
        
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
        public string MATNR1 {
            get {
                return this.mATNR1Field;
            }
            set {
                this.mATNR1Field = value;
                this.RaisePropertyChanged("MATNR1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string EAN11 {
            get {
                return this.eAN11Field;
            }
            set {
                this.eAN11Field = value;
                this.RaisePropertyChanged("EAN11");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string PRICE {
            get {
                return this.pRICEField;
            }
            set {
                this.pRICEField = value;
                this.RaisePropertyChanged("PRICE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string KONWA {
            get {
                return this.kONWAField;
            }
            set {
                this.kONWAField = value;
                this.RaisePropertyChanged("KONWA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public string MEINS {
            get {
                return this.mEINSField;
            }
            set {
                this.mEINSField = value;
                this.RaisePropertyChanged("MEINS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public int GESME {
            get {
                return this.gESMEField;
            }
            set {
                this.gESMEField = value;
                this.RaisePropertyChanged("GESME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GESMESpecified {
            get {
                return this.gESMEFieldSpecified;
            }
            set {
                this.gESMEFieldSpecified = value;
                this.RaisePropertyChanged("GESMESpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date", Order=9)]
        public System.DateTime DATAB {
            get {
                return this.dATABField;
            }
            set {
                this.dATABField = value;
                this.RaisePropertyChanged("DATAB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DATABSpecified {
            get {
                return this.dATABFieldSpecified;
            }
            set {
                this.dATABFieldSpecified = value;
                this.RaisePropertyChanged("DATABSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=10)]
        public string PERNO {
            get {
                return this.pERNOField;
            }
            set {
                this.pERNOField = value;
                this.RaisePropertyChanged("PERNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=11)]
        public string GUBUN {
            get {
                return this.gUBUNField;
            }
            set {
                this.gUBUNField = value;
                this.RaisePropertyChanged("GUBUN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=12)]
        public string GUBUN_T {
            get {
                return this.gUBUN_TField;
            }
            set {
                this.gUBUN_TField = value;
                this.RaisePropertyChanged("GUBUN_T");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=13)]
        public string ZFLAG {
            get {
                return this.zFLAGField;
            }
            set {
                this.zFLAGField = value;
                this.RaisePropertyChanged("ZFLAG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=14)]
        public string ZFLAG_T {
            get {
                return this.zFLAG_TField;
            }
            set {
                this.zFLAG_TField = value;
                this.RaisePropertyChanged("ZFLAG_T");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=15)]
        public int ZCNT {
            get {
                return this.zCNTField;
            }
            set {
                this.zCNTField = value;
                this.RaisePropertyChanged("ZCNT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ZCNTSpecified {
            get {
                return this.zCNTFieldSpecified;
            }
            set {
                this.zCNTFieldSpecified = value;
                this.RaisePropertyChanged("ZCNTSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=16)]
        public decimal STPRC {
            get {
                return this.sTPRCField;
            }
            set {
                this.sTPRCField = value;
                this.RaisePropertyChanged("STPRC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool STPRCSpecified {
            get {
                return this.sTPRCFieldSpecified;
            }
            set {
                this.sTPRCFieldSpecified = value;
                this.RaisePropertyChanged("STPRCSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=17)]
        public decimal TOTAL {
            get {
                return this.tOTALField;
            }
            set {
                this.tOTALField = value;
                this.RaisePropertyChanged("TOTAL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TOTALSpecified {
            get {
                return this.tOTALFieldSpecified;
            }
            set {
                this.tOTALFieldSpecified = value;
                this.RaisePropertyChanged("TOTALSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=18)]
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LABSTSpecified {
            get {
                return this.lABSTFieldSpecified;
            }
            set {
                this.lABSTFieldSpecified = value;
                this.RaisePropertyChanged("LABSTSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=19)]
        public decimal LABST_1 {
            get {
                return this.lABST_1Field;
            }
            set {
                this.lABST_1Field = value;
                this.RaisePropertyChanged("LABST_1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LABST_1Specified {
            get {
                return this.lABST_1FieldSpecified;
            }
            set {
                this.lABST_1FieldSpecified = value;
                this.RaisePropertyChanged("LABST_1Specified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=20)]
        public decimal TOQTY {
            get {
                return this.tOQTYField;
            }
            set {
                this.tOQTYField = value;
                this.RaisePropertyChanged("TOQTY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TOQTYSpecified {
            get {
                return this.tOQTYFieldSpecified;
            }
            set {
                this.tOQTYFieldSpecified = value;
                this.RaisePropertyChanged("TOQTYSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=21)]
        public string NOCTL {
            get {
                return this.nOCTLField;
            }
            set {
                this.nOCTLField = value;
                this.RaisePropertyChanged("NOCTL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=22)]
        public string ZRSUM {
            get {
                return this.zRSUMField;
            }
            set {
                this.zRSUMField = value;
                this.RaisePropertyChanged("ZRSUM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=23)]
        public string BISMT {
            get {
                return this.bISMTField;
            }
            set {
                this.bISMTField = value;
                this.RaisePropertyChanged("BISMT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=24)]
        public string EKGRP {
            get {
                return this.eKGRPField;
            }
            set {
                this.eKGRPField = value;
                this.RaisePropertyChanged("EKGRP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=25)]
        public decimal DPTPR {
            get {
                return this.dPTPRField;
            }
            set {
                this.dPTPRField = value;
                this.RaisePropertyChanged("DPTPR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DPTPRSpecified {
            get {
                return this.dPTPRFieldSpecified;
            }
            set {
                this.dPTPRFieldSpecified = value;
                this.RaisePropertyChanged("DPTPRSpecified");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://eland.co.kr/KRERP/MOB")]
    public partial class SaveMaterialLabelQuery_sync : object, System.ComponentModel.INotifyPropertyChanged {
        
        private MaterialPriceList materialPriceListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public MaterialPriceList MaterialPriceList {
            get {
                return this.materialPriceListField;
            }
            set {
                this.materialPriceListField = value;
                this.RaisePropertyChanged("MaterialPriceList");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://eland.co.kr/KRERP/MOB", ConfigurationName="MANAGESAVEMATERIALLABEL.ManageSaveMaterialLabel")]
    public interface ManageSaveMaterialLabel {
        
        // CODEGEN: Generating message contract since the operation SaveMaterialLabelQueryResponse_In is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.StandardMessageFault), Action="", Name="StandardMessageFault", Namespace="http://sap.com/xi/SAPGlobal/Global")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InResponse SaveMaterialLabelQueryResponse_In(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InResponse> SaveMaterialLabelQueryResponse_InAsync(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveMaterialLabelQueryResponse_InRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://eland.co.kr/KRERP/MOB", Order=0)]
        public Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQuery_sync SaveMaterialLabelQuery_sync;
        
        public SaveMaterialLabelQueryResponse_InRequest() {
        }
        
        public SaveMaterialLabelQueryResponse_InRequest(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQuery_sync SaveMaterialLabelQuery_sync) {
            this.SaveMaterialLabelQuery_sync = SaveMaterialLabelQuery_sync;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveMaterialLabelQueryResponse_InResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://eland.co.kr/KRERP/MOB", Order=0)]
        public Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelResponse_sync SaveMaterialLabelResponse_sync;
        
        public SaveMaterialLabelQueryResponse_InResponse() {
        }
        
        public SaveMaterialLabelQueryResponse_InResponse(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelResponse_sync SaveMaterialLabelResponse_sync) {
            this.SaveMaterialLabelResponse_sync = SaveMaterialLabelResponse_sync;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ManageSaveMaterialLabelChannel : Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.ManageSaveMaterialLabel, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManageSaveMaterialLabelClient : System.ServiceModel.ClientBase<Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.ManageSaveMaterialLabel>, Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.ManageSaveMaterialLabel {
        
        public ManageSaveMaterialLabelClient() {
        }
        
        public ManageSaveMaterialLabelClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManageSaveMaterialLabelClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManageSaveMaterialLabelClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManageSaveMaterialLabelClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InResponse Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.ManageSaveMaterialLabel.SaveMaterialLabelQueryResponse_In(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InRequest request) {
            return base.Channel.SaveMaterialLabelQueryResponse_In(request);
        }
        
        public Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelResponse_sync SaveMaterialLabelQueryResponse_In(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQuery_sync SaveMaterialLabelQuery_sync) {
            Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InRequest inValue = new Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InRequest();
            inValue.SaveMaterialLabelQuery_sync = SaveMaterialLabelQuery_sync;
            Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InResponse retVal = ((Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.ManageSaveMaterialLabel)(this)).SaveMaterialLabelQueryResponse_In(inValue);
            return retVal.SaveMaterialLabelResponse_sync;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InResponse> Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.ManageSaveMaterialLabel.SaveMaterialLabelQueryResponse_InAsync(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InRequest request) {
            return base.Channel.SaveMaterialLabelQueryResponse_InAsync(request);
        }
        
        public System.Threading.Tasks.Task<Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InResponse> SaveMaterialLabelQueryResponse_InAsync(Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQuery_sync SaveMaterialLabelQuery_sync) {
            Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InRequest inValue = new Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.SaveMaterialLabelQueryResponse_InRequest();
            inValue.SaveMaterialLabelQuery_sync = SaveMaterialLabelQuery_sync;
            return ((Eland.NRSM.Template.MANAGESAVEMATERIALLABEL.ManageSaveMaterialLabel)(this)).SaveMaterialLabelQueryResponse_InAsync(inValue);
        }
    }
}