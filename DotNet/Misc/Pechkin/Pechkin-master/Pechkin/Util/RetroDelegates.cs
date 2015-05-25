using System;

namespace Pechkin.Util
{
    internal delegate TResult PechkinFunc<TResult>();
    internal delegate TResult PechkinFunc<T, TResult>(T t);
}
