import { Injectable } from '@angular/core';
import notify from 'devextreme/ui/notify';

@Injectable({ providedIn: 'root' })
export class ToastService {

	private readonly coordinatePosition = <any>{
		top: 60,
		bottom: undefined,
		left: undefined,
		right: 10,
	};

	public success(text: string) {
		this.message(text, 'success');
	}

	public error(text: string) {
		this.message(text, 'error');
	}

	public warning(text: string) {
		this.message(text, 'warning');
	}

	public saveSuccess() {
		this.success('Данные успешно сохранены');
	}	

	public saveFailed(error: any = null): void {
		if (error && error.errors && error.errors.GlobalErrors) {
			this.error(error.errors.GlobalErrors[0]);
		}
		else {
			this.error('Во время выполнения произошла ошибка');
		}
	}

	public message(text: string, type: string): void {
		notify(
			{
				message: text,
				width: 350,
				minWidth: 250,
				type: type,
				displayTime: 3000,
				animation: {
					show: {
						type: 'fade', duration: 400, from: 0, to: 1,
					},
					hide: { type: 'fade', duration: 40, to: 0 },
				},
			},
			{
				position: this.coordinatePosition,
				direction: 'down-push'
			}
		);
	}
}