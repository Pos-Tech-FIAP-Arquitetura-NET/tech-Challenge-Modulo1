import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor, HttpResponse, HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import {AuthServiceService} from "./auth-service.service";
import {Router} from "@angular/router";

@Injectable()
export class AuthserviceInterceptor implements HttpInterceptor {

  constructor(
    public authService: AuthServiceService,
    private router: Router
  ) {}

  addToken(req: HttpRequest<any>, token: string): HttpRequest<any> {
    const requisition = req.clone({ setHeaders: { Authorization: 'Bearer ' + token } });
    console.log(requisition)
    return requisition
  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return new Observable<HttpEvent<any>>(subscriber => {
      req = this.addToken(req, this.authService.getAccessToken());
      next.handle(req)
        .subscribe((event: HttpEvent<any>) => {
            if (event instanceof HttpResponse)
            {
              subscriber.next(event);
              subscriber.complete();
            }
          },
          error => {
            if (error instanceof HttpErrorResponse && error.status === 401) {
              this.router.navigate(['/login']);
              return

            } else {
              if (error instanceof HttpErrorResponse && error.status === 500) {
                console.log(error);
              }
              subscriber.error(error);
            }
          });
    });
  }



}
