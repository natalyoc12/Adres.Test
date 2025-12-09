import { Mapper } from '../../../base/mapper';
import { ProcurementModel } from '../../../domain/models/procurement.model';
import { ProcurementEntity } from '../entities/procurement-entity';

export class ProcurementMapper extends Mapper<
  ProcurementEntity,
  ProcurementModel
> {
  override mapFrom(param: ProcurementEntity): ProcurementModel {
    return {
      ...param,
    };
  }

  override mapTo(param: ProcurementModel): ProcurementEntity {
    throw new Error('Method not implemented.');
  }
}
