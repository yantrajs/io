import { opendirSync, readdirSync } from "fs";

export interface IDirectoryEntry {
    name: string;
    isDirectory: boolean;
    isLink: boolean;
    isFile: boolean;
}

export default class Directory {

    public static *enumerateFiles(folder: string): Iterable<IDirectoryEntry> {
        const dir = opendirSync(folder);
        do {
            const entry = dir.readSync();
            if (!entry) {
                break;
            }
            yield {
                name: entry.name,
                isDirectory: entry.isDirectory(),
                isLink: entry.isSymbolicLink(),
                isFile: entry.isFile()
            };
        } while (true);
    }

}
