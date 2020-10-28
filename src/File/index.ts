import { readFileSync, writeFileSync } from "fs";

export default class File {

    /**
     * Writes given contents to file
     * @param filePath local file path
     * @param contents contents to write
     * @param encoding encoding, default is utf-8
     */
    public static writeAllText(filePath: string, contents: string, encoding: BufferEncoding = "utf-8") {
        return writeFileSync(filePath, contents, encoding);
    }

    /**
     * Reads contents of given file
     * @param filePath local file path
     * @param encoding encoding, default is utf-8
     */
    public static readAllText(filePath: string, encoding: BufferEncoding = "utf-8") {
        return readFileSync(filePath, encoding);
    }
}
