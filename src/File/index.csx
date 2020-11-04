#r "nuget: YantraJS.Core,1.0.5"
using System;
using System.Linq;
using YantraJS.Core;
using YantraJS.Core.Clr;

[DefaultExport]
public class File {

    public static JSValue WriteAllTextAsync(in Arguments a) {
        var (a1, a2, a3) = a.Get3();
        var filePath = a1.ToString();
        var contents = a2.ToString();
        var encoding = a3.AsStringOrDefault("utf-8");
        var task = System.IO.File.WriteAllTextAsync(filePath, contents, System.Text.Encoding.GetEncoding(encoding));
        return task.Marshal();
    }

    public static JSValue WriteAllText(in Arguments a) {
        var (a1, a2, a3) = a.Get3();
        var filePath = a1.ToString();
        var contents = a2.ToString();
        var encoding = a3.AsStringOrDefault("utf-8");
        System.IO.File.WriteAllText(filePath, contents, System.Text.Encoding.GetEncoding(encoding));
        return JSUndefined.Value;
    }

    public static JSValue ReadAllText(in Arguments a) {
        var (a1, a2) = a.Get2();
        var filePath = a1.ToString();
        var encoding = a2.AsStringOrDefault("utf-8");
        var contents = System.IO.File.ReadAllText(filePath, System.Text.Encoding.GetEncoding(encoding));
        return new JSString(contents);
    }

    public static JSValue ReadAllTextAsync(in Arguments a) {
        var (a1, a2) = a.Get2();
        var filePath = a1.ToString();
        var encoding = a2.AsStringOrDefault("utf-8");
        var contents = System.IO.File.ReadAllTextAsync(filePath, System.Text.Encoding.GetEncoding(encoding));
        return contents.Marshal();
    }

}
