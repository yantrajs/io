import { opendirSync, readdirSync } from "fs";
import { parse } from "path";

export interface IDirectoryEntry {
    /**
     * Full path of parent directory
     */
    parent: string;

    /**
     * Name of the file
     */
    name: string;

    /**
     * Extension of the file
     */
    ext: string;

    /**
     * Full path of the file
     */
    fullName: string;
    isDirectory: boolean;
    isFile: boolean;
}

export default class Directory {

    public static *enumerateFiles(folder: string): Iterable<IDirectoryEntry> {
        if (!folder) {
            throw new TypeError("Folder is required");
        }
        const dir = opendirSync(folder);
        do {
            const entry = dir.readSync();
            if (!entry) {
                break;
            }
            const path = parse(entry.name);
            yield {
                fullName: entry.name,
                name: path.base,
                ext: path.ext,
                parent: path.dir,
                isDirectory: entry.isDirectory(),
                isFile: entry.isFile()
            };
        } while (true);
    }

}
