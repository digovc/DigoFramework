using System;

namespace DigoFramework.Anotacao
{
    /// <summary>
    /// Indica se a propriedade será salva no arquivo de configuração da aplicação (AppConfig). Esta
    /// anotação deve ser utilizada em apenas classes que derivam de <see cref="ConfigMain"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AppConfigInvisivel : Attribute
    {
    }
}