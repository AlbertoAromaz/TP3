﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34011
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CondominioTest.ResidenteWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Residente", Namespace="http://schemas.datacontract.org/2004/07/CondominioService.MasterTables.Dominio")]
    [System.SerializableAttribute()]
    public partial class Residente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoMaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoPaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CelularField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CorreoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaCreacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaNacimientoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NroDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SexoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioCreacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioModificacionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoMaterno {
            get {
                return this.ApellidoMaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoMaternoField, value) != true)) {
                    this.ApellidoMaternoField = value;
                    this.RaisePropertyChanged("ApellidoMaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoPaterno {
            get {
                return this.ApellidoPaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoPaternoField, value) != true)) {
                    this.ApellidoPaternoField = value;
                    this.RaisePropertyChanged("ApellidoPaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Celular {
            get {
                return this.CelularField;
            }
            set {
                if ((object.ReferenceEquals(this.CelularField, value) != true)) {
                    this.CelularField = value;
                    this.RaisePropertyChanged("Celular");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((this.CodigoField.Equals(value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Correo {
            get {
                return this.CorreoField;
            }
            set {
                if ((object.ReferenceEquals(this.CorreoField, value) != true)) {
                    this.CorreoField = value;
                    this.RaisePropertyChanged("Correo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((object.ReferenceEquals(this.EstadoField, value) != true)) {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaCreacion {
            get {
                return this.FechaCreacionField;
            }
            set {
                if ((this.FechaCreacionField.Equals(value) != true)) {
                    this.FechaCreacionField = value;
                    this.RaisePropertyChanged("FechaCreacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaModificacion {
            get {
                return this.FechaModificacionField;
            }
            set {
                if ((this.FechaModificacionField.Equals(value) != true)) {
                    this.FechaModificacionField = value;
                    this.RaisePropertyChanged("FechaModificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaNacimiento {
            get {
                return this.FechaNacimientoField;
            }
            set {
                if ((this.FechaNacimientoField.Equals(value) != true)) {
                    this.FechaNacimientoField = value;
                    this.RaisePropertyChanged("FechaNacimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombres {
            get {
                return this.NombresField;
            }
            set {
                if ((object.ReferenceEquals(this.NombresField, value) != true)) {
                    this.NombresField = value;
                    this.RaisePropertyChanged("Nombres");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NroDocumento {
            get {
                return this.NroDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.NroDocumentoField, value) != true)) {
                    this.NroDocumentoField = value;
                    this.RaisePropertyChanged("NroDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sexo {
            get {
                return this.SexoField;
            }
            set {
                if ((object.ReferenceEquals(this.SexoField, value) != true)) {
                    this.SexoField = value;
                    this.RaisePropertyChanged("Sexo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoDocumento {
            get {
                return this.TipoDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoDocumentoField, value) != true)) {
                    this.TipoDocumentoField = value;
                    this.RaisePropertyChanged("TipoDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioCreacion {
            get {
                return this.UsuarioCreacionField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioCreacionField, value) != true)) {
                    this.UsuarioCreacionField = value;
                    this.RaisePropertyChanged("UsuarioCreacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioModificacion {
            get {
                return this.UsuarioModificacionField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioModificacionField, value) != true)) {
                    this.UsuarioModificacionField = value;
                    this.RaisePropertyChanged("UsuarioModificacion");
                }
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/CondominioService.MasterTables.Dominio")]
    [System.SerializableAttribute()]
    public partial class RepetidoException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoField, value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mensaje {
            get {
                return this.MensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeField, value) != true)) {
                    this.MensajeField = value;
                    this.RaisePropertyChanged("Mensaje");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ResidenteWS.IResidenteService")]
    public interface IResidenteService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/CrearResidente", ReplyAction="http://tempuri.org/IResidenteService/CrearResidenteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(CondominioTest.ResidenteWS.RepetidoException), Action="http://tempuri.org/IResidenteService/CrearResidenteRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/CondominioService.MasterTables.Dominio")]
        CondominioTest.ResidenteWS.Residente CrearResidente(CondominioTest.ResidenteWS.Residente residente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/CrearResidente", ReplyAction="http://tempuri.org/IResidenteService/CrearResidenteResponse")]
        System.Threading.Tasks.Task<CondominioTest.ResidenteWS.Residente> CrearResidenteAsync(CondominioTest.ResidenteWS.Residente residente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/ObtenerResidente", ReplyAction="http://tempuri.org/IResidenteService/ObtenerResidenteResponse")]
        CondominioTest.ResidenteWS.Residente ObtenerResidente(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/ObtenerResidente", ReplyAction="http://tempuri.org/IResidenteService/ObtenerResidenteResponse")]
        System.Threading.Tasks.Task<CondominioTest.ResidenteWS.Residente> ObtenerResidenteAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/ModificarResidente", ReplyAction="http://tempuri.org/IResidenteService/ModificarResidenteResponse")]
        CondominioTest.ResidenteWS.Residente ModificarResidente(CondominioTest.ResidenteWS.Residente residente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/ModificarResidente", ReplyAction="http://tempuri.org/IResidenteService/ModificarResidenteResponse")]
        System.Threading.Tasks.Task<CondominioTest.ResidenteWS.Residente> ModificarResidenteAsync(CondominioTest.ResidenteWS.Residente residente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/EliminarResidente", ReplyAction="http://tempuri.org/IResidenteService/EliminarResidenteResponse")]
        void EliminarResidente(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/EliminarResidente", ReplyAction="http://tempuri.org/IResidenteService/EliminarResidenteResponse")]
        System.Threading.Tasks.Task EliminarResidenteAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/listarResidentes", ReplyAction="http://tempuri.org/IResidenteService/listarResidentesResponse")]
        CondominioTest.ResidenteWS.Residente[] listarResidentes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IResidenteService/listarResidentes", ReplyAction="http://tempuri.org/IResidenteService/listarResidentesResponse")]
        System.Threading.Tasks.Task<CondominioTest.ResidenteWS.Residente[]> listarResidentesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IResidenteServiceChannel : CondominioTest.ResidenteWS.IResidenteService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ResidenteServiceClient : System.ServiceModel.ClientBase<CondominioTest.ResidenteWS.IResidenteService>, CondominioTest.ResidenteWS.IResidenteService {
        
        public ResidenteServiceClient() {
        }
        
        public ResidenteServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ResidenteServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ResidenteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ResidenteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CondominioTest.ResidenteWS.Residente CrearResidente(CondominioTest.ResidenteWS.Residente residente) {
            return base.Channel.CrearResidente(residente);
        }
        
        public System.Threading.Tasks.Task<CondominioTest.ResidenteWS.Residente> CrearResidenteAsync(CondominioTest.ResidenteWS.Residente residente) {
            return base.Channel.CrearResidenteAsync(residente);
        }
        
        public CondominioTest.ResidenteWS.Residente ObtenerResidente(int codigo) {
            return base.Channel.ObtenerResidente(codigo);
        }
        
        public System.Threading.Tasks.Task<CondominioTest.ResidenteWS.Residente> ObtenerResidenteAsync(int codigo) {
            return base.Channel.ObtenerResidenteAsync(codigo);
        }
        
        public CondominioTest.ResidenteWS.Residente ModificarResidente(CondominioTest.ResidenteWS.Residente residente) {
            return base.Channel.ModificarResidente(residente);
        }
        
        public System.Threading.Tasks.Task<CondominioTest.ResidenteWS.Residente> ModificarResidenteAsync(CondominioTest.ResidenteWS.Residente residente) {
            return base.Channel.ModificarResidenteAsync(residente);
        }
        
        public void EliminarResidente(int codigo) {
            base.Channel.EliminarResidente(codigo);
        }
        
        public System.Threading.Tasks.Task EliminarResidenteAsync(int codigo) {
            return base.Channel.EliminarResidenteAsync(codigo);
        }
        
        public CondominioTest.ResidenteWS.Residente[] listarResidentes() {
            return base.Channel.listarResidentes();
        }
        
        public System.Threading.Tasks.Task<CondominioTest.ResidenteWS.Residente[]> listarResidentesAsync() {
            return base.Channel.listarResidentesAsync();
        }
    }
}
