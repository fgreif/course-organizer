import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfigService } from '../config.service';
import { EnhancedFormControl, EnhancedFormGroup } from '../enhancedformgroup';

import { LvaService } from '../lva.service';
import { Lva } from '../models/lva';

@Component({
  selector: 'app-lva-create-form',
  templateUrl: './lva-create-form.component.html',
  styleUrls: ['./lva-create-form.component.css']
})
export class LvaCreateFormComponent implements OnInit{ 
  addressForm = EnhancedFormGroup.create({
    lvaName: new EnhancedFormControl<string>(),
    lvaTeacher: new EnhancedFormControl<string>(),
    lvaNumber: new EnhancedFormControl<number>(),
    lvaType: new EnhancedFormControl<number>(),
    lvaRoom: new EnhancedFormControl<string>(),
    lvaInstitute: new EnhancedFormControl<string>(),
    lvaExam: new EnhancedFormControl<Date | null>(),
    lvaEcts: new EnhancedFormControl<number>(),
  })
  lva = new Lva();

  constructor(private _fb: FormBuilder, private readonly _lvaService: LvaService) {}

  ngOnInit() {
    this.addressForm = EnhancedFormGroup.create({
      lvaName: new EnhancedFormControl<string>('', Validators.required),
      lvaTeacher: new EnhancedFormControl<string>('', Validators.required),
      lvaNumber: new EnhancedFormControl<number>('', Validators.required),
      lvaType: new EnhancedFormControl<number>('', Validators.required),
      lvaRoom: new EnhancedFormControl<string>('', Validators.required),
      lvaInstitute: new EnhancedFormControl<string>('', Validators.required),
      lvaExam: new EnhancedFormControl<Date | null>(),
      lvaEcts: new EnhancedFormControl<number>('', Validators.required),
    })
  }
  onSubmit(): void {
    const fv = this.addressForm.value;
    console.log(fv.lvaName);
    this.lva.lvaName = fv.lvaName;
    this.lva.lvaTeacher = fv.lvaTeacher;
    this.lva.lvaNumber = fv.lvaNumber;
    this.lva.lvaType = fv.lvaType;
    this.lva.lvaRoom = fv.lvaRoom;
    this.lva.lvaInstitute = fv.lvaInstitute;
    this.lva.lvaExam = fv.lvaExam;
    this.lva.lvaEcts = fv.lvaEcts;
  
    this._lvaService.createLva(this.lva).subscribe(i => {
      alert('Thanks!');
      console.log("LVA Created!");
    });
  }


}
