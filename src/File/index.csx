#r "nuget: YantraJS.Core, 1.0.1-CI-20201024-043043"
using System;
using WebAtoms.CoreJS.Core;
using WebAtoms.CoreJS.Core.Clr;

[DefaultExport]
public class File {

    public static JSValue WriteAllText(in Arguments a) {
        try {
            var (a1, a2, a3) = a.Get3();
            var filePath = a1.ToString();
            var contents = a2.ToString();
            var encoding = a3.AsStringOrDefault("utf-8");
            System.IO.File.WriteAllText(filePath, contents, System.Text.Encoding.GetEncoding(encoding));
            return JSUndefined.Value;
        } catch (Exception ex) {
            throw JSContext.Current.NewError(ex.Message);
        }
    }

    public static JSValue ReadAllText(in Arguments a) {
        try {
            var (a1, a2) = a.Get2();
            var filePath = a1.ToString();
            var encoding = a2.AsStringOrDefault("utf-8");
            var contents = System.IO.File.ReadAllText(filePath, System.Text.Encoding.GetEncoding(encoding));
            return new JSString(contents);
        } catch (Exception ex) {
            throw JSContext.Current.NewError(ex.Message);
        }
    }
}
