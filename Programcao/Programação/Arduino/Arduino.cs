using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino
{
    class Arduino
    {
        private String codigo;
        private String dataHora;
        private String dispositivo;
        private String acao;
       

        public void setCodigo(String _codigo) { codigo = _codigo; }
        public void setDataHora(String _dataHora) { dataHora = _dataHora; }
        public void setDispositivo(String _dispositivo) { dispositivo = _dispositivo; }
        public void setAcao(String _acao) { acao = _acao; }
       

        public String getCodigo() { return codigo; }
        public String getDataHora() { return dataHora; }
        public String getDispositivo() { return dispositivo; }
        public String getAcao() { return acao; }
        
    }
}
