#r "nuget: YantraJS.Core, 1.0.1-CI-20201024-043043"
using System;
using System.IO;
using WebAtoms.CoreJS.Core;
using WebAtoms.CoreJS.Core.Clr;

[DefaultExport]
public class YDirectory {

    private static IEnumerable<JSValue> Enumerate(string folder, string pattern) {
        var dir = new DirectoryInfo(folder);
        foreach(var en in dir.EnumerateFileSystemInfos()) {
            var entry = new JSObject();
            entry["name"] = new JSString(en.FullName);
            if(en is FileInfo fi) {
                entry["isDirectory"] = JSBoolean.False;
                entry["isFile"] = JSBoolean.True;
                entry["ext"] = fi.Extension.ToJSValue();
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
        var folder = a1.AsStringOrDefault();
        var pattern = a2.AsStringOrDefault();
        return new ClrProxy(Enumerate(folder, pattern));
    }

}
