export default class RequestException extends Error {
	constructor(url) {
		super(`RequestException: ${url}`);
		this.name = "RequestException";
	}
}