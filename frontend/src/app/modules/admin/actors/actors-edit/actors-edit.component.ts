import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ActorGetByIdEndpointService} from '../../../../endpoints/actor-endpoints/actor-get-by-id-endpoint.service';
import {ActorUpdateOrInsertEndpointService} from '../../../../endpoints/actor-endpoints/actor-update-or-insert-endpoint.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-actors-edit',
  templateUrl: './actors-edit.component.html',
  styleUrls: ['./actors-edit.component.css'],
  standalone: false
})
export class ActorsEditComponent implements OnInit {
  actorForm: FormGroup;
  isEditMode = false;
  actorId: number | null = null;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private actorGetService: ActorGetByIdEndpointService,
    private actorUpdateService: ActorUpdateOrInsertEndpointService
  ) {
    this.actorForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.maxLength(50)]]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id'];
      if (id && id !== 'new') {
        this.isEditMode = true;
        this.actorId = +id;
        this.loadActor(this.actorId);
      } else {
        this.isEditMode = false;
        this.actorId = null;
      }
    });
  }

  loadActor(id: number): void {
    this.actorGetService.handleAsync(id).subscribe({
      next: (actor) => {
        this.actorForm.patchValue({
          firstName: actor.firstName,
          lastName: actor.lastName
        });
      },
      error: (err) => {
        console.error('Error loading actor:', err);
      }
    });
  }

  onSubmit(): void {
    if (this.actorForm.valid) {
      const actorData = {
        id: this.actorId || undefined,
        firstName: this.actorForm.get('firstName')?.value,
        lastName: this.actorForm.get('lastName')?.value
      };

      this.actorUpdateService.handleAsync(actorData).subscribe({
        next: () => {
          console.log('Actor saved successfully');
          this.router.navigate(['/admin/actors']);
        },
        error: (err) => {
          console.error('Error saving actor:', err);
        }
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['/admin/actors']);
  }
} 