% 1. Parametrelerin Tanımlanması
%Referans yol parametreleri
dy1 = 3.5;
dy2 = 3.5;
dx1 = 25;
dx2 = 25;
ds1 = 60;
ds2 = 130;
alpha = 2.4;

% Araç hızı
vx = 20;

% Kazançlar (oransal kontrol)
ky = 0.8;
kpsi = 1.2;

% 2. Referans Yol Fonksiyonlarının Tanımlanması
X = 0:0.5:200; % Aracın ilerlediği X konumları

z1 = (alpha/dx1)*(X -ds1) - alpha/2;
z2 = (alpha/dx2)*(X -ds2) - alpha/2;

Yref = (dy1/2) * (1 + tanh(z1)) - (dy2/2)*(1 + tanh(z2));

% 3. Yönelim Açıları
dYref_dX = (dy1 * (1 ./ cosh(z1)).^2) * (alpha /(2*dx1)) - (dy2 * (1 ./ cosh(z2)).^2*(alpha/(2*dx2)));

psiref = atan(dYref_dX); %Referans yönelim açısı(radyan)


% 4. Hata Hesaplama

Y_arac = zeros(size(X)); % Araç y konumu (hep 0)
psi_arac = zeros(size(X)); % Araç yönelimi (hep 0)

ey = Yref - Y_arac;
epsi = psiref - psi_arac;

% 5. Eğrilik Talebi Hesaplanması
kappa_des = ky * ey + kpsi * epsi;

% 6. Sonuçların çizdirilmesi
figure;
subplot(3,1,1)
plot(X, Yref); title('Yref (Referans Yol)'); xlabel('X [m]'); ylabel('Y [m]');

subplot(3,1,2)
plot(X, psiref*180/pi); title('Psi_ref (Referans Yönelim)'); xlabel('X [m]'); ylabel('psi [deg]');

subplot(3,1,3)
plot(X, kappa_des); title('Eğrilik Talebi - \kappa_{des}'); xlabel('X [m]'); ylabel('\kappa');

