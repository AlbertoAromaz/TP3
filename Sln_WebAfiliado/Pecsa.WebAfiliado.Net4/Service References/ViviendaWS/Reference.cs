﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pecsa.WebAfiliado.Net4.ViviendaWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Vivienda", Namespace="http://schemas.datacontract.org/2004/07/CondominioService.MasterTables.Dominio")]
    [System.SerializableAttribute()]
    public partial class Vivienda : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoViviendaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaCreacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal MetrajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NroBanoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NroCuartosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumeroViviendaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool TieneSalaComedorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Pecsa.WebAfiliado.Net4.ViviendaWS.TipoVivienda TipoViviendaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Pecsa.WebAfiliado.Net4.ViviendaWS.Ubicacion UbicacionField;
        
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
        public int CodigoVivienda {
            get {
                return this.CodigoViviendaField;
            }
            set {
                if ((this.CodigoViviendaField.Equals(value) != true)) {
                    this.CodigoViviendaField = value;
                    this.RaisePropertyChanged("CodigoVivienda");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((this.EstadoField.Equals(value) != true)) {
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
        public decimal Metraje {
            get {
                return this.MetrajeField;
            }
            set {
                if ((this.MetrajeField.Equals(value) != true)) {
                    this.MetrajeField = value;
                    this.RaisePropertyChanged("Metraje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NroBano {
            get {
                return this.NroBanoField;
            }
            set {
                if ((this.NroBanoField.Equals(value) != true)) {
                    this.NroBanoField = value;
                    this.RaisePropertyChanged("NroBano");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NroCuartos {
            get {
                return this.NroCuartosField;
            }
            set {
                if ((this.NroCuartosField.Equals(value) != true)) {
                    this.NroCuartosField = value;
                    this.RaisePropertyChanged("NroCuartos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumeroVivienda {
            get {
                return this.NumeroViviendaField;
            }
            set {
                if ((this.NumeroViviendaField.Equals(value) != true)) {
                    this.NumeroViviendaField = value;
                    this.RaisePropertyChanged("NumeroVivienda");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool TieneSalaComedor {
            get {
                return this.TieneSalaComedorField;
            }
            set {
                if ((this.TieneSalaComedorField.Equals(value) != true)) {
                    this.TieneSalaComedorField = value;
                    this.RaisePropertyChanged("TieneSalaComedor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Pecsa.WebAfiliado.Net4.ViviendaWS.TipoVivienda TipoVivienda {
            get {
                return this.TipoViviendaField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoViviendaField, value) != true)) {
                    this.TipoViviendaField = value;
                    this.RaisePropertyChanged("TipoVivienda");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Pecsa.WebAfiliado.Net4.ViviendaWS.Ubicacion Ubicacion {
            get {
                return this.UbicacionField;
            }
            set {
                if ((object.ReferenceEquals(this.UbicacionField, value) != true)) {
                    this.UbicacionField = value;
                    this.RaisePropertyChanged("Ubicacion");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoVivienda", Namespace="http://schemas.datacontract.org/2004/07/CondominioService.MasterTables.Dominio")]
    [System.SerializableAttribute()]
    public partial class TipoVivienda : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoTipoViviendaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaCreacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreTipoViviendaField;
        
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
        public int CodigoTipoVivienda {
            get {
                return this.CodigoTipoViviendaField;
            }
            set {
                if ((this.CodigoTipoViviendaField.Equals(value) != true)) {
                    this.CodigoTipoViviendaField = value;
                    this.RaisePropertyChanged("CodigoTipoVivienda");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((this.EstadoField.Equals(value) != true)) {
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
        public string NombreTipoVivienda {
            get {
                return this.NombreTipoViviendaField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreTipoViviendaField, value) != true)) {
                    this.NombreTipoViviendaField = value;
                    this.RaisePropertyChanged("NombreTipoVivienda");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Ubicacion", Namespace="http://schemas.datacontract.org/2004/07/CondominioService.MasterTables.Dominio")]
    [System.SerializableAttribute()]
    public partial class Ubicacion : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoUbicacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaCreacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUbicacionField;
        
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
        public int CodigoUbicacion {
            get {
                return this.CodigoUbicacionField;
            }
            set {
                if ((this.CodigoUbicacionField.Equals(value) != true)) {
                    this.CodigoUbicacionField = value;
                    this.RaisePropertyChanged("CodigoUbicacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((this.EstadoField.Equals(value) != true)) {
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
        public string NombreUbicacion {
            get {
                return this.NombreUbicacionField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreUbicacionField, value) != true)) {
                    this.NombreUbicacionField = value;
                    this.RaisePropertyChanged("NombreUbicacion");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ViviendaWS.IViviendaService")]
    public interface IViviendaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IViviendaService/CrearVivienda", ReplyAction="http://tempuri.org/IViviendaService/CrearViviendaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Pecsa.WebAfiliado.Net4.ViviendaWS.RepetidoException), Action="http://tempuri.org/IViviendaService/CrearViviendaRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/CondominioService.MasterTables.Dominio")]
        Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda CrearVivienda(int codigoTipoVivienda, int codigoUbicación, int numeroVivienda, decimal metraje, bool tieneSalaComedor, int nroCuartos, int nroBanos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IViviendaService/ObtenerVivienda", ReplyAction="http://tempuri.org/IViviendaService/ObtenerViviendaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Pecsa.WebAfiliado.Net4.ViviendaWS.RepetidoException), Action="http://tempuri.org/IViviendaService/ObtenerViviendaRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/CondominioService.MasterTables.Dominio")]
        Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda ObtenerVivienda(int codigoVivienda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IViviendaService/ModificarVivienda", ReplyAction="http://tempuri.org/IViviendaService/ModificarViviendaResponse")]
        Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda ModificarVivienda(int codigoVivienda, int codigoTipoVivienda, int codigoUbicación, int numeroVivienda, decimal metraje, bool tieneSalaComedor, int nroCuartos, int nroBanos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IViviendaService/EliminarVivienda", ReplyAction="http://tempuri.org/IViviendaService/EliminarViviendaResponse")]
        void EliminarVivienda(int codigoVivienda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IViviendaService/ListarViviendas", ReplyAction="http://tempuri.org/IViviendaService/ListarViviendasResponse")]
        Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda[] ListarViviendas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IViviendaService/BuscarVivienda", ReplyAction="http://tempuri.org/IViviendaService/BuscarViviendaResponse")]
        Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda[] BuscarVivienda(int codigoTipoVivienda, int codigoUbicacion, int numeroVivienda);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IViviendaServiceChannel : Pecsa.WebAfiliado.Net4.ViviendaWS.IViviendaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ViviendaServiceClient : System.ServiceModel.ClientBase<Pecsa.WebAfiliado.Net4.ViviendaWS.IViviendaService>, Pecsa.WebAfiliado.Net4.ViviendaWS.IViviendaService {
        
        public ViviendaServiceClient() {
        }
        
        public ViviendaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ViviendaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ViviendaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ViviendaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda CrearVivienda(int codigoTipoVivienda, int codigoUbicación, int numeroVivienda, decimal metraje, bool tieneSalaComedor, int nroCuartos, int nroBanos) {
            return base.Channel.CrearVivienda(codigoTipoVivienda, codigoUbicación, numeroVivienda, metraje, tieneSalaComedor, nroCuartos, nroBanos);
        }
        
        public Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda ObtenerVivienda(int codigoVivienda) {
            return base.Channel.ObtenerVivienda(codigoVivienda);
        }
        
        public Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda ModificarVivienda(int codigoVivienda, int codigoTipoVivienda, int codigoUbicación, int numeroVivienda, decimal metraje, bool tieneSalaComedor, int nroCuartos, int nroBanos) {
            return base.Channel.ModificarVivienda(codigoVivienda, codigoTipoVivienda, codigoUbicación, numeroVivienda, metraje, tieneSalaComedor, nroCuartos, nroBanos);
        }
        
        public void EliminarVivienda(int codigoVivienda) {
            base.Channel.EliminarVivienda(codigoVivienda);
        }
        
        public Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda[] ListarViviendas() {
            return base.Channel.ListarViviendas();
        }
        
        public Pecsa.WebAfiliado.Net4.ViviendaWS.Vivienda[] BuscarVivienda(int codigoTipoVivienda, int codigoUbicacion, int numeroVivienda) {
            return base.Channel.BuscarVivienda(codigoTipoVivienda, codigoUbicacion, numeroVivienda);
        }
    }
}
