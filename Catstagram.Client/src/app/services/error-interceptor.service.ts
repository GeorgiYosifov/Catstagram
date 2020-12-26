import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

  constructor(private toastrService: ToastrService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retry(1),
      catchError(error => {
        let message = "";
        if (error.status === 401) {
          message = "Token has expired or you should be logged in.";
        }
        else if (error.status === 404) {
          message = "404";
        }
        else if (error.status === 400) {
          message = "400";
        }
        else {
          message = "Unexpected error";
        }

        this.toastrService.error(message);
        return throwError(error);
      })
    )
  }
}
