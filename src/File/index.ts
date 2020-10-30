import { readFile, readFileSync, writeFile, writeFileSync } from "fs";
import { promisify } from "util";

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
     * Writes given contents to file asynchronously
     * @param filePath local file path
     * @param contents contents to write
     * @param encoding encoding, default is utf-8
     */
    public static writeAllTextAsync(
        filePath: string, contents: string, encoding: BufferEncoding = "utf-8"): Promise<void> {
        return promisify(writeFile)(filePath, contents, encoding);
    }

    /**
     * Reads contents of given file
     * @param filePath local file path
     * @param encoding encoding, default is utf-8
     */
    public static readAllText(filePath: string, encoding: BufferEncoding = "utf-8") {
        return readFileSync(filePath, encoding);
    }

    /**
     * Read contents of the file asynchronously
     * @param filePath local file path
     * @param encoding encoding, default is utf-8
     */
    public static readAllTextAsync(filePath: string, encoding: BufferEncoding = "utf-8"): Promise<string> {
        return promisify(readFile)(filePath, encoding);
    }
}
