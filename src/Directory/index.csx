#r "nuget: YantraJS.Core,1.0.5"
using System;
using System.Linq;
using YantraJS.Core;
using YantraJS.Core.Clr;
using System.IO;

[DefaultExport]
public class YDirectory {

    private static IEnumerable<JSValue> Enumerate(JSValue folder, string pattern) {
        var dir = new DirectoryInfo(folder.AsStringOrDefault());
        foreach(var en in dir.EnumerateFileSystemInfos()) {
            var entry = new JSObject();
            entry["name"] = en.Name.Marshal();
            entry["fullName"] = en.FullName.Marshal();
            entry["parent"] = folder.Marshal();
            if(en is FileInfo fi) {
                entry["isDirectory"] = JSBoolean.False;
                entry["isFile"] = JSBoolean.True;
                entry["ext"] = fi.Extension.Marshal();
            } else {
                entry["isDirectory"] = JSBoolean.True;
                entry["isFile"] = JSBoolean.False;
                entry["ext"] = JSUndefined.Value;
            }
            yield return entry;
        }
    }

    public static JSValue EnumerateFiles(in Arguments a) {
        var (a1, a2) = a.Get2();
        if (a1.IsNull || a1.IsUndefined)
            throw JSContext.Current.NewTypeError("Folder is required");
        var pattern = a2.AsStringOrDefault();
        return new ClrProxy(Enumerate(a1, pattern));
    }

}
