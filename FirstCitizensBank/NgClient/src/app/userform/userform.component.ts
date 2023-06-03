import { Component } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-userform',
  templateUrl: './userform.component.html',
  styleUrls: ['./userform.component.css']
})
export class UserFormComponent {
  firstName!: string;
  lastName!: string;
  zipCode!: string;
  statusMessage!: string;

  constructor(private dataService: DataService) {}

  submitForm(): void {
    if (!this.firstName || !this.lastName || !this.zipCode) {
      this.statusMessage = 'Please fill in all fields.';
      return;
    }

    this.dataService.submitData(this.firstName, this.lastName, this.zipCode)
      .subscribe(
        (response: string) => this.statusMessage = response,
        (_error: any) => { this.statusMessage = 'An error occurred while submitting the form.'; }
      );
  }
}
