'use client'
import { AccentButton, ButtonGroup } from "@/components/buttons";
import useEmblaCarousel from "embla-carousel-react";
import { createRef, useCallback } from "react";
import styles from "./Carousel.module.scss";
import { useDotButton } from "./hooks/useDotButton";

interface CarouselProps {
    children: React.ReactElement[]
    additionalButtons?: React.ReactElement | React.ReactElement[]
		className?: string
    buttonsClassName?: string
		footerClassName?: string
}

export default function Carousel({children, additionalButtons, className, footerClassName, buttonsClassName}: CarouselProps) {
  const [emblaRef, emblaApi] = useEmblaCarousel({ loop: true })
  const dotsRef = createRef<HTMLDivElement>()

  const scrollNext = useCallback(() => {
    if (emblaApi) emblaApi.scrollNext()
  }, [emblaApi])

  const { selectedIndex, onDotButtonClick } = useDotButton(emblaApi)

  return (
    <div className={`${styles.embla} ${className}`}>
        <div className={styles.embla__viewport} ref={emblaRef}>
            <div className={styles.embla__container}>
							{children.map((o, i) => {
									return <div key={i} className={styles.embla__slide}>{o}</div>
							})}
            </div>
        </div>
        <div className={`${styles.embla__footer} ${footerClassName}`}>
            <div className={styles.embla__dots} ref={dotsRef}>
								{children.map((_, i) => {
										return <div
											key={i}
											onClick={() => onDotButtonClick(i)}
											className={`${styles.embla__dot} ${i === selectedIndex && styles['embla__dot--selected']}`}
										/>
								})}
            </div>
            <ButtonGroup className={`${styles.embla__buttons} ${buttonsClassName}`}>
                {additionalButtons}
                <AccentButton onClick={scrollNext}>Далі</AccentButton>
            </ButtonGroup>
        </div>
    </div>
  );
}
