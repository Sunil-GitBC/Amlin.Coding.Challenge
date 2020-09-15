export class ResponseData<T> {
    data: T;
    success: boolean;
    errors: string[];
    message: string;
}
