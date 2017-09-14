import { SaveVehicle } from './../models/vehicle';
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  constructor(
    private http: Http,
    @Inject('ORIGIN_URL') private originUrl: string) { }

  getMakes() {
    return this.http.get(this.originUrl + '/api/makes')
      .map(res => res.json());
  }

  getFeatures() {
    return this.http.get(this.originUrl + '/api/features')
      .map(res => res.json());
  }

  create(vehicle) {
    return this.http.post(this.originUrl + '/api/vehicles', vehicle)
      .map(res => res.json());
  }

  getVehicle(id) {
    return this.http.get(this.originUrl + '/api/vehicles/' + id)
      .map(res => res.json());
  }

  getVehicles(filter) {
    return this.http.get(this.originUrl + '/api/vehicles?' + this.toQueryString(filter))
      .map(res => res.json());
  }

  toQueryString(obj) {
    let parts = [];

    for (let property in obj) {
      const value = obj[property];
      if (value != null && value != undefined)
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));

      return parts.join('&');
    }
  }

  update(vehicle: SaveVehicle) {
    return this.http.put(this.originUrl + '/api/vehicles/' + vehicle.id, vehicle)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete(this.originUrl + '/api/vehicles/' + id)
      .map(res => res.json());
  }
}
