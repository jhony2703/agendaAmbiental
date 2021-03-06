﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgendaAmbiental_v6.LoginServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoginServiceReference.ILoginService")]
    public interface ILoginService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/NuevaSesion", ReplyAction="http://tempuri.org/ILoginService/NuevaSesionResponse")]
        string NuevaSesion(int idAplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/NuevaSesion", ReplyAction="http://tempuri.org/ILoginService/NuevaSesionResponse")]
        System.Threading.Tasks.Task<string> NuevaSesionAsync(int idAplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/HolaMundo", ReplyAction="http://tempuri.org/ILoginService/HolaMundoResponse")]
        string HolaMundo(int idAplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/HolaMundo", ReplyAction="http://tempuri.org/ILoginService/HolaMundoResponse")]
        System.Threading.Tasks.Task<string> HolaMundoAsync(int idAplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/NuevaSesionConUrlRetorno", ReplyAction="http://tempuri.org/ILoginService/NuevaSesionConUrlRetornoResponse")]
        string NuevaSesionConUrlRetorno(int idAplicacion, string ReturnUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/NuevaSesionConUrlRetorno", ReplyAction="http://tempuri.org/ILoginService/NuevaSesionConUrlRetornoResponse")]
        System.Threading.Tasks.Task<string> NuevaSesionConUrlRetornoAsync(int idAplicacion, string ReturnUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/NuevaSesionConUsuario", ReplyAction="http://tempuri.org/ILoginService/NuevaSesionConUsuarioResponse")]
        string NuevaSesionConUsuario(string usuario, int idAplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/NuevaSesionConUsuario", ReplyAction="http://tempuri.org/ILoginService/NuevaSesionConUsuarioResponse")]
        System.Threading.Tasks.Task<string> NuevaSesionConUsuarioAsync(string usuario, int idAplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/NuevaSesionConUsuarioYUrlRetorno", ReplyAction="http://tempuri.org/ILoginService/NuevaSesionConUsuarioYUrlRetornoResponse")]
        string NuevaSesionConUsuarioYUrlRetorno(int idAplicacion, string usuario, string ReturnUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/NuevaSesionConUsuarioYUrlRetorno", ReplyAction="http://tempuri.org/ILoginService/NuevaSesionConUsuarioYUrlRetornoResponse")]
        System.Threading.Tasks.Task<string> NuevaSesionConUsuarioYUrlRetornoAsync(int idAplicacion, string usuario, string ReturnUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/ValidaCliente", ReplyAction="http://tempuri.org/ILoginService/ValidaClienteResponse")]
        int ValidaCliente(int Ticket, string ClaveSesion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/ValidaCliente", ReplyAction="http://tempuri.org/ILoginService/ValidaClienteResponse")]
        System.Threading.Tasks.Task<int> ValidaClienteAsync(int Ticket, string ClaveSesion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/EstadoUsuario", ReplyAction="http://tempuri.org/ILoginService/EstadoUsuarioResponse")]
        string EstadoUsuario(int Ticket, string ClaveSesion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/EstadoUsuario", ReplyAction="http://tempuri.org/ILoginService/EstadoUsuarioResponse")]
        System.Threading.Tasks.Task<string> EstadoUsuarioAsync(int Ticket, string ClaveSesion);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoginServiceChannel : AgendaAmbiental_v6.LoginServiceReference.ILoginService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginServiceClient : System.ServiceModel.ClientBase<AgendaAmbiental_v6.LoginServiceReference.ILoginService>, AgendaAmbiental_v6.LoginServiceReference.ILoginService {
        
        public LoginServiceClient() {
        }
        
        public LoginServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string NuevaSesion(int idAplicacion) {
            return base.Channel.NuevaSesion(idAplicacion);
        }
        
        public System.Threading.Tasks.Task<string> NuevaSesionAsync(int idAplicacion) {
            return base.Channel.NuevaSesionAsync(idAplicacion);
        }
        
        public string HolaMundo(int idAplicacion) {
            return base.Channel.HolaMundo(idAplicacion);
        }
        
        public System.Threading.Tasks.Task<string> HolaMundoAsync(int idAplicacion) {
            return base.Channel.HolaMundoAsync(idAplicacion);
        }
        
        public string NuevaSesionConUrlRetorno(int idAplicacion, string ReturnUrl) {
            return base.Channel.NuevaSesionConUrlRetorno(idAplicacion, ReturnUrl);
        }
        
        public System.Threading.Tasks.Task<string> NuevaSesionConUrlRetornoAsync(int idAplicacion, string ReturnUrl) {
            return base.Channel.NuevaSesionConUrlRetornoAsync(idAplicacion, ReturnUrl);
        }
        
        public string NuevaSesionConUsuario(string usuario, int idAplicacion) {
            return base.Channel.NuevaSesionConUsuario(usuario, idAplicacion);
        }
        
        public System.Threading.Tasks.Task<string> NuevaSesionConUsuarioAsync(string usuario, int idAplicacion) {
            return base.Channel.NuevaSesionConUsuarioAsync(usuario, idAplicacion);
        }
        
        public string NuevaSesionConUsuarioYUrlRetorno(int idAplicacion, string usuario, string ReturnUrl) {
            return base.Channel.NuevaSesionConUsuarioYUrlRetorno(idAplicacion, usuario, ReturnUrl);
        }
        
        public System.Threading.Tasks.Task<string> NuevaSesionConUsuarioYUrlRetornoAsync(int idAplicacion, string usuario, string ReturnUrl) {
            return base.Channel.NuevaSesionConUsuarioYUrlRetornoAsync(idAplicacion, usuario, ReturnUrl);
        }
        
        public int ValidaCliente(int Ticket, string ClaveSesion) {
            return base.Channel.ValidaCliente(Ticket, ClaveSesion);
        }
        
        public System.Threading.Tasks.Task<int> ValidaClienteAsync(int Ticket, string ClaveSesion) {
            return base.Channel.ValidaClienteAsync(Ticket, ClaveSesion);
        }
        
        public string EstadoUsuario(int Ticket, string ClaveSesion) {
            return base.Channel.EstadoUsuario(Ticket, ClaveSesion);
        }
        
        public System.Threading.Tasks.Task<string> EstadoUsuarioAsync(int Ticket, string ClaveSesion) {
            return base.Channel.EstadoUsuarioAsync(Ticket, ClaveSesion);
        }
    }
}
